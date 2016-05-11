using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OneTeam.SDK.VK.Models.LongPoll;
using System.Threading;
using OneTeam.SDK.VK.Models.Common;
using Newtonsoft.Json;
using System.Net.Http;
using OneTeam.SDK.Core;
using OneTeam.SDK.VK.Services.Interfaces;

namespace OneTeam.SDK.VK.Services
{
    /// <summary>
    /// Представляет сервис для работы с LongPoll-подключением к ВКонтакте.
    /// </summary>
    public sealed class VKLongPollService : IVKLongPollService
    {
        private const string LONGPOLL_CONNECTION_MASK = "http://{0}?act=a_check&key={1}&ts={2}&wait={3}&mode={4}";
        private const byte LONGPOLL_MODE = 2;
        private const byte LONGPOLL_WAIT = 25;
        private const byte MAX_RETRIES_NUMBER = 5;

        private readonly object lockObject = new object();
        private CancellationTokenSource cts;
        
        private IVKService vkService;

        /// <summary>
        /// Просиходит при запуске сервиса.
        /// </summary>
        public event TypedEventHandler<IVKLongPollService, EventArgs> ServiceStarted;
        /// <summary>
        /// Происходит при остановке сервиса.
        /// </summary>
        public event TypedEventHandler<IVKLongPollService, VKLongPollServiceStopReason> ServiceStopped;
        /// <summary>
        /// Происходит при получении новых обновлений.
        /// </summary>
        public event TypedEventHandler<IVKLongPollService, IReadOnlyList<IVKLongPollUpdate>> UpdatesReceived;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VKLongPollService"/>.
        /// </summary>        
        /// <param name="vkService">Сервис работы с ВКонтакте.</param>
        public VKLongPollService(IVKService vkService)
        {
            this.vkService = vkService;
        }

        /// <summary>
        /// Режим отладки. Выводятся подробные данные о состоянии сервиса.
        /// </summary>
        public bool DebugMode { get; set; }
        /// <summary>
        /// Работает ли в данный момент сервис.
        /// </summary>
        public bool IsWorking { get; private set; }

        /// <summary>
        /// Запустить LongPoll сервис.
        /// </summary>
        public async void Start()
        {
            if (IsWorking) return;

            try
            {
                IsWorking = true;
                cts = new CancellationTokenSource();
                if (ServiceStarted != null)
                    ServiceStarted(this, EventArgs.Empty);
                
                await ProcessLongPoll();
            }
            catch (OperationCanceledException)
            {
                OnServiceStopped(VKLongPollServiceStopReason.ByUser);
            }
            catch (WebConnectionException)
            {
                OnServiceStopped(VKLongPollServiceStopReason.ConnectionError);
            }
            catch (Exception)
            {
                OnServiceStopped(VKLongPollServiceStopReason.InternalError);
                throw;
            }
        }

        /// <summary>
        /// Остановить LongPoll сервис.
        /// </summary>
        public void Stop()
        {
            if (!IsWorking) return;
            
            cts.Cancel();
            cts = null;               
        }

        /// <summary>
        /// Запускает процесс работы LongPoll.
        /// </summary>
        private async Task ProcessLongPoll()
        {
            var serverData = await GetServerData();

            while (serverData != null)
            {
                var response = await GetResponse(serverData);

                if (response.Error == VKLongPollErrors.None)
                {
                    serverData.Ts = response.Ts;
                    OnUpdatesReceived(response);
                }
                else if (response.Error == VKLongPollErrors.DataIsOutdated)
                {
                    serverData.Ts = response.Ts;
                }
                else if (response.Error == VKLongPollErrors.DataIsCorrupted ||
                        response.Error == VKLongPollErrors.KeyIsExpired)
                {
                    serverData = await GetServerData();
                }
            }

            throw new Exception("Exit from main LongPoll loop");
        }

        /// <summary>
        /// Возвращает данные для подключения к LongPoll серверу.
        /// </summary>
        private async Task<VKLongPollServerData> GetServerData()
        {
            byte currentRetry = 0;
            while (currentRetry < MAX_RETRIES_NUMBER)
            {
                var request = new Request<VKLongPollServerData>("messages.getLongPollServer", token: cts.Token);
                var response = await vkService.ExecuteRequestAsync(request);

                if (response.IsSuccess) return response.Response;                
                else if (response.Error == VKErrors.ConnectionError)
                {
                    if (++currentRetry < MAX_RETRIES_NUMBER)
                    {
                        int timeout = currentRetry * 5;
                        await Task.Delay(timeout * 1000, cts.Token);
                        continue;
                    }
                }
            }
            
            throw new Exception("Exit from GetServerData loop");
        }

        /// <summary>
        /// Вызывается при остановке сервиса.
        /// </summary>
        /// <param name="reason">Причина остановки.</param>
        private void OnServiceStopped(VKLongPollServiceStopReason reason)
        {
            IsWorking = false;
            if (ServiceStopped != null) ServiceStopped(this, reason);
        }

        /// <summary>
        /// Вызывается при получении новых обновлений.
        /// </summary>
        /// <param name="response">Данные ответа LongPoll сервера.</param>
        private void OnUpdatesReceived(VKLongPollResponse response)
        {
            if (UpdatesReceived != null)
                UpdatesReceived(this, response.Updates);
        }

        /// <summary>
        /// Выполнить запрос к LongPoll серверу ВКонтакте
        /// </summary>
        /// <param name="data">Данные для подключения.</param>
        private async Task<VKLongPollResponse> GetResponse(VKLongPollServerData data)
        {
            using (var client = new HttpClient())
            {
                byte currentRetry = 0;
                while (currentRetry < MAX_RETRIES_NUMBER)
                {
                    HttpResponseMessage response = null;
                    try
                    {
                        response = await client.GetAsync(new Uri(String.Format(
                            LONGPOLL_CONNECTION_MASK, data.Server, data.Key, data.Ts,
                            LONGPOLL_WAIT, LONGPOLL_MODE)), cts.Token);
                    }
                    catch (OperationCanceledException) { throw; }
                    catch (Exception)
                    {
                        if (++currentRetry < MAX_RETRIES_NUMBER)
                        {
                            int timeout = currentRetry * 5;
                            await Task.Delay(timeout * 1000, cts.Token);
                            continue;
                        }
                    }

                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<VKLongPollResponse>(json);
                }
            }

            throw new Exception("Exit from GetResponse loop");
        }
    }
}
