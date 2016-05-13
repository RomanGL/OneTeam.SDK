using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneTeam.SDK.LastFm.Services.Interfaces;
using OneTeam.SDK.Core;
using OneTeam.SDK.LastFm.Models.Response;
using OneTeam.SDK.LastFm.Models.Common;
using System.Net.Http;

namespace OneTeam.SDK.LastFm.Services
{
    /// <summary>
    /// Представляет сервис для работы с Last.fm.
    /// </summary>
    public sealed class LFService : ILFService
    {
        private const string API_ROOT = "http://ws.audioscrobbler.com/2.0/";
        private const string API_RESPONSE_FORMAT = "json";

        private readonly string ApiKey;

        public LFService(string apiKey)
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// Выполняет указанный запрос к Last.fm и возвращает ответ.
        /// </summary>
        /// <typeparam name="T">Тип результирующих данных.</typeparam>
        /// <param name="request">Объект запроса к Last.fm.</param>
        public async Task<T> ExecuteRequestAsync<T>(IRequest<T> request) where T : LFResponse
        {
            return await ProcessRequestAsync(request);
        }

        /// <summary>
        /// Выполняет указанный запрос к Last.fm и возвращает ответ.
        /// </summary>
        /// <typeparam name="T">Тип результирующих данных.</typeparam>
        /// <param name="request">Объект запроса к Last.fm.</param>
        private async Task<T> ProcessRequestAsync<T>(IRequest<T> request) where T : LFResponse
        {
            var parameters = request.GetParameters();
            parameters["method"] = request.GetMethod();
            parameters["api_key"] = ApiKey;
            parameters["format"] = API_RESPONSE_FORMAT;

            T response = null;
            string json = String.Empty;

            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage httpResponse = null;
                    if (request.HttpMethod == Core.Models.HttpMethod.GET)
                        httpResponse = await client.GetAsync(new Uri(API_ROOT + GetRequestUrl(parameters)));
                    else
                        httpResponse = await client.PostAsync(new Uri(API_ROOT), new FormUrlEncodedContent(parameters));

                    json = await httpResponse.Content.ReadAsStringAsync();
                }
            }
            catch (OperationCanceledException)
            {
                response = Activator.CreateInstance<T>();
                response.SetError(LFErrors.OperationCanceled, "Operation canceled");
                return response;
            }
            catch (Exception) { }

            if (String.IsNullOrEmpty(json))
            {
                response = Activator.CreateInstance<T>();
                response.SetError(LFErrors.ConnectionError, "Connection error");
                return response;
            }

            try { response = JsonConvert.DeserializeObject<T>(json); }
            catch (Exception)
            {
                response = Activator.CreateInstance<T>();
                response.SetError(LFErrors.DeserializationError, "Data is corrupted.\nJSON: " + json);
            }

            return response;
        }

        /// <summary>
        /// Возвращает строку для GET-запроса к Last.fm.
        /// </summary>
        /// <param name="parameters">Параметры метода.</param>
        private static string GetRequestUrl(Dictionary<string, string> parameters)
        {
            return "?" + String.Join("&", parameters.Select(
                kp => Uri.EscapeDataString(kp.Key) + "=" + Uri.EscapeDataString(kp.Value)));
        }
    }
}
