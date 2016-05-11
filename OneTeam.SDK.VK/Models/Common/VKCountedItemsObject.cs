using Newtonsoft.Json;

namespace OneTeam.SDK.VK.Models.Common
{
    /// <summary>
    /// Представляет собой списковый ответ ВКонтакте на запрос.
    /// </summary>
    public class VKCountedItemsObject<T> : VKBaseItemsObject<T>
    {
        /// <summary>
        /// Общее количество элементов.
        /// </summary>
        [JsonProperty("count")]
        public uint Count { get; set; }        
    }
}
