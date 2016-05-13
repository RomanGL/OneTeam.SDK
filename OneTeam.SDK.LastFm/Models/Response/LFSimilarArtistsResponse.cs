using Newtonsoft.Json;
using OneTeam.SDK.LastFm.Models.Audio;

namespace OneTeam.SDK.LastFm.Models.Response
{
    /// <summary>
    /// Представляет ответ на запрос подобных исполнителей Last.fm.
    /// </summary>
    public class LFSimilarArtistsResponse : LFResponse
    {
        /// <summary>
        /// Объект списка исполнителей.
        /// </summary>
        [JsonProperty("similarartists")]
        public LFSimilarArtists Data { get; set; }

        /// <summary>
        /// Являются ли данные валидными.
        /// </summary>
        public override bool IsValid()
        {
            return Data != null && Data.IsValid();
        }
    }
}
