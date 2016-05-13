using Newtonsoft.Json;
using System.Collections.Generic;

namespace OneTeam.SDK.LastFm.Models.Common
{
    /// <summary>
    /// Представляет объект тегов Last.fm.
    /// </summary>
    public class LFTags
    {
        /// <summary>
        /// Список тегов.
        /// </summary>
        [JsonProperty("tag")]
        public List<LFTag> Tags { get; set; }
    }
}
