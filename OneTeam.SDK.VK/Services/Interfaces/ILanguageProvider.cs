using OneTeam.SDK.VK.Models.Common;

namespace OneTeam.SDK.VK.Services.Interfaces
{
    /// <summary>
    /// Предоставляет метод для получения языка запросов.
    /// </summary>
    public interface ILanguageProvider
    {
        /// <summary>
        /// Возвращает язык, на котором должны возвращаться данные при запросах к ВКонтакте.
        /// </summary>
        Language GetLanguage();
    }
}
