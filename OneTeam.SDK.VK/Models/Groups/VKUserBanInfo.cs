using Newtonsoft.Json;
using OneTeam.SDK.Core.Json;
using System;

namespace OneTeam.SDK.VK.Models.Groups
{
    /// <summary>
    /// Информация о блокировке пользователя в сообществе.
    /// </summary>
    public sealed class VKUserBanInfo
    {
        /// <summary>
        /// Срок окончания блокировки.
        /// </summary>
        [JsonConverter(typeof(UnixtimeToDateTimeConverter))]
        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Комментарий к блокировке.
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; }
    }
}
