using OneTeam.SDK.Core.Models;
using System.Collections.Generic;
using System.Threading;

namespace OneTeam.SDK.Core
{
	/// <summary>
	/// Представляет запрос к веб-сервису.
	/// </summary>
    /// <typeparam name="T">Тип результирующих данных.</typeparam>
    public interface IRequest<T>
    {
        /// <summary>
        /// Возвращает токен отмены операции.
        /// </summary>
        CancellationToken Token { get; }

        /// <summary>
        /// Возвращает полный метод, для которого предназначен запрос.
        /// </summary>
        string GetMethod();

        /// <summary>
        /// Возвращает HTTP-метод, с которым нужно выполнить запрос к веб-сервису.
        /// </summary>
        HttpMethod HttpMethod { get; }

        /// <summary>
        /// Возвращает словарь параметров.
        /// </summary>
        Dictionary<string, string> GetParameters();
    }
}
