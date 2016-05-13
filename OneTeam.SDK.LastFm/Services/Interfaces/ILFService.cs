using OneTeam.SDK.Core;
using OneTeam.SDK.LastFm.Models.Response;
using System.Threading.Tasks;

namespace OneTeam.SDK.LastFm.Services.Interfaces
{
    /// <summary>
    /// Представляет сервис для работы с Last.fm.
    /// </summary>
    public interface ILFService
    {
        /// <summary>
        /// Выполняет указанный запрос к Last.fm и возвращает ответ.
        /// </summary>
        /// <typeparam name="T">Тип результирующих данных.</typeparam>
        /// <param name="request">Объект запроса к Last.fm.</param>
        Task<T> ExecuteRequestAsync<T>(IRequest<T> request) where T : LFResponse;
    }
}
