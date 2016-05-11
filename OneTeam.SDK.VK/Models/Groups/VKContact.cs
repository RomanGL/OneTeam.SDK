using Newtonsoft.Json;

namespace OneTeam.SDK.VK.Models.Groups
{
    /// <summary>
    /// Контакт раздела контактов ВКонтакте.
    /// </summary>
    public sealed class VKContact
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        [JsonProperty("user_id")]
        public long UserID { get; set; }
        /// <summary>
        /// Описание контакта.
        /// </summary>
        [JsonProperty("desc")]
        public string Description { get; set; }
        /// <summary>
        /// Электронная почта контакта.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
        /// <summary>
        /// Номер телефона контакта.
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}
