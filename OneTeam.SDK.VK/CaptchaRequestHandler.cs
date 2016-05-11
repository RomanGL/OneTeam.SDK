using OneTeam.SDK.VK.Models.Common;
using System.Threading.Tasks;

namespace OneTeam.SDK.VK
{
    /// <summary>
    /// Представляет метод, обрабатывающий запрос ввода каптчи.
    /// </summary>
    /// <param name="request">Запрос каптчи.</param>
    public delegate Task<VKCaptchaResponse> CaptchaRequestHandler(VKCaptchaRequest request);
}
