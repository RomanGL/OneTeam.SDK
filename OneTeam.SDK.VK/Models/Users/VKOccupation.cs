using Newtonsoft.Json;
namespace OneTeam.SDK.VK.Models.Users
{
    /// <summary>
    /// Представляет собой информацию о роде деятельности пользователя.
    /// </summary>
    public sealed class VKOccupation
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

        /// <summary>
        /// Тип рода деятельности.
        /// </summary>
        [JsonProperty("type")]
        public VKOccupationType Occupation { get; set; }
    }
}
