using Newtonsoft.Json;

namespace OneTeam.SDK.VK.Models.Users
{
    /// <summary>
    /// Представляет собой телефонные номера пользователя ВКонтакте.
    /// </summary>
    public sealed class VKUserContacts
    {
        /// <summary>
        /// Мобильный телефон пользователя.
        /// </summary>
        [JsonProperty("mobile_phone")]
        public string MobilePhone { get; set; }
        
        /// <summary>
        /// Домашний телефон пользователя.
        /// </summary>
        [JsonProperty("home_phone")]
        public string HomePhone { get; set; }
    }
}
