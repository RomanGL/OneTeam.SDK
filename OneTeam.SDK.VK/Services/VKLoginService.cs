using OneTeam.SDK.Core;
using OneTeam.SDK.Core.Services.Interfaces;
using OneTeam.SDK.VK.Models.Common;
using OneTeam.SDK.VK.Services.Interfaces;
using System;

namespace OneTeam.SDK.VK.Services
{
    /// <summary>
    /// Представляет сервис авторизации ВКонтакте.
    /// </summary>
    public sealed class VKLoginService : IVKLoginService
    {
        public const string ACCESS_TOKEN_PARAMETER = "AccessToken";
        private const string AUTHORIZATION_URL = "https://oauth.vk.com/authorize";
        private const string REDIRECT_URL = "https://oauth.vk.com/blank.html";
        private const string PARAMETERS_MASK = "{0}?client_id={1}&scope={2}&redirect_uri={3}&display=popup&v={4}&response_type=token";
        private const string SCOPE = "audio,friends,docs,groups,offline,status,video,wall";

        private ISettingsService settingsService;
        private readonly int clientID;

        private VKAccessToken AccessToken { get { return settingsService?.Get<VKAccessToken>(ACCESS_TOKEN_PARAMETER); } }

        /// <summary>
        /// Просиходит при успешной авторизации пользователя.
        /// </summary>
        public event TypedEventHandler<IVKLoginService, EventArgs> UserLogin;
        /// <summary>
        /// Происходит при выходе пользователя.
        /// </summary>
        public event TypedEventHandler<IVKLoginService, EventArgs> UserLogout;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VKLoginService"/>.
        /// </summary>
        /// <param name="clientID">Идентификатор приложения ВКонтакте.</param>
        /// <param name="settingsService">Сервис настроек.</param>
        public VKLoginService(int clientID, ISettingsService settingsService)
        {
            this.settingsService = settingsService;
            this.clientID = clientID;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VKLoginService"/>.
        /// </summary>
        /// <param name="clientID">Идентификатор приложения ВКонтакте.</param>
        public VKLoginService(int clientID)
        {
            this.clientID = clientID;
        }

        /// <summary>
        /// Возвращает идентификатор текущего авторизованного пользователя.
        /// </summary>
        public long UserID
        {
            get
            {
                if (AccessToken == null)
                    throw new InvalidOperationException("Авторизация не выполнена.");
                return AccessToken.UserID;
            }
        }

        /// <summary>
        /// Возвращает токен авторизованного пользователя.
        /// </summary>
        public string Token
        {
            get
            {
                if (AccessToken == null)
                    throw new InvalidOperationException("Авторизация не выполнена.");
                return AccessToken.AccessToken;
            }
        }

        /// <summary>
        /// Возвращает значение, выполнена ли авторизация.
        /// </summary>
        public bool IsAuthorized { get { return AccessToken != null; } }

        /// <summary>
        /// Возвращает адрес для oAuth-авторизации ВКонтакте.
        /// </summary>
        public string GetOAuthUrl()
        {
            return String.Format(PARAMETERS_MASK, AUTHORIZATION_URL, clientID, SCOPE, REDIRECT_URL, Constants.API_VERSION);
        }

        /// <summary>
        /// Возвращает ключ доступа к ВКонтакте из redireted-пути oAuth.
        /// </summary>
        /// <param name="oAuthUrl">Путь.</param>
        public VKAccessToken GetAccessTokenFromUrl(string oAuthUrl)
        {
            var response = oAuthUrl.Split(new char[] { '#' })[1].Split(new char[] { '&' });
            string token = response[0].Split('=')[1];
            long userID = long.Parse(response[2].Split('=')[1]);

            return new VKAccessToken
            {
                UserID = userID,
                AccessToken = token
            };
        }

        /// <summary>
        /// Выполняет авторизацию по указанному токену.
        /// </summary>
        /// <param name="token">Токен авторизации.</param>
        public void Login(VKAccessToken token)
        {
            settingsService?.Set(ACCESS_TOKEN_PARAMETER, token);
            UserLogin?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Отменить авторизацию ВКонтакте.
        /// </summary>
        public void Logout()
        {
            settingsService?.Remove(ACCESS_TOKEN_PARAMETER);
            UserLogout?.Invoke(this, EventArgs.Empty);
        }
    }
}
