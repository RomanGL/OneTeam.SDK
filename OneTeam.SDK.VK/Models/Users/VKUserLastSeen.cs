using Newtonsoft.Json;
using System;
using OneTeam.SDK.VK.Models.Common;
using OneTeam.SDK.Core.Json;

namespace OneTeam.SDK.VK.Models.Users
{
    /// <summary>
    /// Объект времени последнего посещения ВКонтакте.
    /// </summary>
    public sealed class VKLastSeen
    {
        /// <summary>
        /// Платформа, с которой заходил пользователь.
        /// </summary>
        [JsonProperty("platform")]
        public VKPlatform Platform { get; set; }
        /// <summary>
        /// Время и дата последнего посещения.
        /// </summary>
        [JsonProperty("time")]
        [JsonConverter(typeof(UnixtimeToDateTimeConverter))]
        public DateTime Time { get; set; }
    }
}
