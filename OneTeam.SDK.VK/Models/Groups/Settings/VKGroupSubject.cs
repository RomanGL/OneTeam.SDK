using Newtonsoft.Json;

namespace OneTeam.SDK.VK.Models.Groups
{
    /// <summary>
    /// Представляет элемент тематики сообщества.
    /// </summary>
    public sealed class VKGroupSubject
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [JsonProperty("id")]
        public uint ID { get; set; }
        /// <summary>
        /// Название.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
