﻿using Newtonsoft.Json;

namespace OneTeam.SDK.LastFm.Models.Audio
{
    /// <summary>
    /// Предаствляет подобного исполнителя Last.fm.
    /// </summary>
    public class LFSimilarArtist : LFArtistExtended
    {
        /// <summary>
        /// Степень похожести на текущего исполнителя.
        /// </summary>
        [JsonProperty("match")]
        public double Match { get; set; }
    }
}
