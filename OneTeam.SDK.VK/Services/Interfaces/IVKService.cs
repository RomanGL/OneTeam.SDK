using OneTeam.SDK.Core;
using OneTeam.SDK.VK.Models.Common;
using System.Threading.Tasks;

namespace OneTeam.SDK.VK.Services.Interfaces
{
    /// <summary>
    /// Представляет сервис для работы с ВКонтакте.
    /// </summary>
    public interface IVKService
    {
        /// <summary>
        /// Метод, выполняющий запрос каптчи у пользователя.
        /// </summary>
        CaptchaRequestHandler CaptchaRequest { get; set; }

        /// <summary>
        /// Выполняет указанный запрос к ВКонтакте и возвращает ответ.
        /// </summary>
        /// <typeparam name="T">Тип результирующих данных.</typeparam>
        /// <param name="request">Объект запроса к ВКонтакте.</param>
        Task<VKResponse<T>> ExecuteRequestAsync<T>(IRequest<T> request);
    }
}
