using Newtonsoft.Json;
using OneTeam.SDK.LastFm.Models.Common;

namespace OneTeam.SDK.LastFm.Models.Audio
{
    /// <summary>
    /// Представляет расширенный трек Last.fm.
    /// </summary>
    public class LFAudioExtended : LFAudioBase
    {
        /// <summary>
        /// Идентификатор трека.
        /// </summary>
        [JsonProperty("id")]
        public long ID { get; set; }        

        /// <summary>
        /// Теги композиции.
        /// </summary>
        [JsonProperty("toptags")]
        public LFTags Tags { get; set; }
    }
}
