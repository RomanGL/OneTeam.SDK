using OneTeam.SDK.VK.Models.Common;
using Newtonsoft.Json;

namespace OneTeam.SDK.VK.Models.Groups
{
    /// <summary>
    /// Представляет счетчики сообщества.
    /// </summary>
    public sealed class VKGroupCounters : VKCountersBase
    {
        /// <summary>
        /// Количество топиков в обсуждении.
        /// </summary>
        [JsonProperty("topics")]
        public uint TopicsCount { get; set; }
        /// <summary>
        /// Количество документов.
        /// </summary>
        [JsonProperty("docs")]
        public uint DocsCount { get; set; }
    }
}
