using Newtonsoft.Json;

namespace OneTeam.SDK.VK.Models.Users
{
    /// <summary>
    /// Представляет список пользователей ВКонтакте.
    /// </summary>
    public sealed class VKUserList
    {
        /// <summary>
        /// Идентификатор школы, вуза или группы компаний
        /// (в которой работает пользователь).
        /// </summary>
        [JsonProperty("id")]
        public uint ID { get; set; }

        /// <summary>
        /// Название школы, выза или места работы.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
