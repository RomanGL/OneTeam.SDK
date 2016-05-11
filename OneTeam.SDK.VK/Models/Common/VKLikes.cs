using Newtonsoft.Json;
using OneTeam.SDK.VK.Json;

namespace OneTeam.SDK.VK.Models.Common
{
    /// <summary>
    /// Представляет информацию о отметках Мне нравится ВКонтакте.
    /// </summary>
    public sealed class VKLikes
    {
        /// <summary>
        /// Количество отметок.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }
        
        /// <summary>
        /// Есть ли отметка от ткущего пользователя.
        /// </summary>
        [JsonProperty("user_likes")]
        [JsonConverter(typeof(VKBooleanConverter))]
        public bool UserLikes { get; set; }
        
        /// <summary>
        /// Может ли текущий пользователь поставить отметку.
        /// </summary>
        [JsonProperty("can_like")]
        [JsonConverter(typeof(VKBooleanConverter))]
        public bool CanLike { get; set; }
        
        /// <summary>
        /// Может ли текущий пользователь сделать репост.
        /// </summary>
        [JsonProperty("can_publish")]
        [JsonConverter(typeof(VKBooleanConverter))]
        public bool CanPublish { get; set; }
    }
}
