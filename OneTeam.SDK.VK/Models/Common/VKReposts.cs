using Newtonsoft.Json;
using OneTeam.SDK.VK.Json;

namespace OneTeam.SDK.VK.Models.Common
{
    /// <summary>
    /// Представляет информацию о репостах.
    /// </summary>
    public sealed class VKReposts
    {
        /// <summary>
        /// Количество репостов.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }
        
        /// <summary>
        /// Скопировал ли текущий пользователь.
        /// </summary>
        [JsonProperty("user_reposted")]
        [JsonConverter(typeof(VKBooleanConverter))]
        public bool UserReposted { get; set; }
    }
}
