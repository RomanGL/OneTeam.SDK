using OneTeam.SDK.Core;
using OneTeam.SDK.VK.Models.Common;
using System;

namespace OneTeam.SDK.VK.Services.Interfaces
{
    /// <summary>
    /// Проедставляет сервис авторизации ВКонтакте.
    /// </summary>
    public interface IVKLoginService
    {
        /// <summary>
        /// Просиходит при успешной авторизации пользователя.
        /// </summary>
        event TypedEventHandler<IVKLoginService, EventArgs> UserLogin;
        /// <summary>
        /// Происходит при выходе пользователя.
        /// </summary>
        event TypedEventHandler<IVKLoginService, EventArgs> UserLogout;

        /// <summary>
        /// Возвращает идентификатор текущего авторизованного пользователя.
        /// </summary>
        long UserID { get; }

        /// <summary>
        /// Возвращает токен авторизации текущего пользователя.
        /// </summary>
        string Token { get; }

        /// <summary>
        /// Возвращает значение, выполнена ли авторизация.
        /// </summary>
        bool IsAuthorized { get; }

        /// <summary>
        /// Возвращает адрес для oAuth-авторизации ВКонтакте.
        /// </summary>
        string GetOAuthUrl();

        /// <summary>
        /// Выполняет авторизацию по полученному токену.
        /// </summary>
        /// <param name="token">Токен авторизации.</param>
        void Login(VKAccessToken token);

        /// <summary>
        /// Возвращает ключ доступа к ВКонтакте из redireted-пути oAuth.
        /// </summary>
        /// <param name="oAuthUrl">Путь.</param>
        VKAccessToken GetAccessTokenFromUrl(string oAuthUrl);

        /// <summary>
        /// Завершает авторизацию.
        /// </summary>
        void Logout();
    }
}
