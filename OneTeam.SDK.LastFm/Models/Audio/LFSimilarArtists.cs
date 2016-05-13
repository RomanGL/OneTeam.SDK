using Newtonsoft.Json;
using OneTeam.SDK.LastFm.Models.Common;
using System.Collections.Generic;

namespace OneTeam.SDK.LastFm.Models.Audio
{
    /// <summary>
    /// Представляет список подобных исполнителей Last.fm.
    /// </summary>
    public class LFSimilarArtists : ISupportValidation
    {
        /// <summary>
        /// Список подобных исполнителей.
        /// </summary>
        [JsonProperty("artist")]
        public List<LFSimilarArtist> Artists { get; set; }

        /// <summary>
        /// Являются ли данные валидными.
        /// </summary>
        public bool IsValid()
        {
            return Artists != null;
        }
    }
}
