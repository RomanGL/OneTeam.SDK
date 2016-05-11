using Newtonsoft.Json;
using OneTeam.SDK.VK.Json;

namespace OneTeam.SDK.VK.Models.Common
{
    /// <summary>
    /// Представляет информацию о комментариях ВКонтакте.
    /// </summary>
    public sealed class VKComments
    {
        /// <summary>
        /// Количество комментариев.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }
        
        /// <summary>
        /// Может ли текущий пользователь комментировать запись.
        /// </summary>
        [JsonProperty("can_post")]
        [JsonConverter(typeof(VKBooleanConverter))]
        public bool CanPost { get; set; }
    }
}
