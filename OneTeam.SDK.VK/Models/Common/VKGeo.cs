using Newtonsoft.Json;

namespace OneTeam.SDK.VK.Models.Common
{
    /// <summary>
    /// Представляет собой информацию о местоположении ВКонтакте.
    /// </summary>
    public sealed class VKGeo
    {
        /// <summary>
        /// Тип места.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
        /// <summary>
        /// Описание места (если добавлено).
        /// </summary>
        [JsonProperty("place")]
        public VKPlace Place { get; set; }
    }
}
