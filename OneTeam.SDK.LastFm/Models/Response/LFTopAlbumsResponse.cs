using Newtonsoft.Json;
using OneTeam.SDK.LastFm.Models.Audio;

namespace OneTeam.SDK.LastFm.Models.Response
{
    /// <summary>
    /// Представляет ответ на запрос топовых треков Last.fm.
    /// </summary>
    public class LFTopAlbumsResponse : LFResponse
    {
        /// <summary>
        /// Объект списка треков.
        /// </summary>
        [JsonProperty("topalbums")]
        public LFAlbums Data { get; set; }

        /// <summary>
        /// Являются ли данные валидными.
        /// </summary>
        public override bool IsValid()
        {
            return Data != null && Data.IsValid();
        }
    }
}
