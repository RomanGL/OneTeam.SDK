using Newtonsoft.Json;
using OneTeam.SDK.LastFm.Models.Audio;

namespace OneTeam.SDK.LastFm.Models.Response.Response
{
    /// <summary>
    /// Представляет ответ сервера Last.fm на запрос чартов исполнителей.
    /// </summary>
    public class LFChartArtistsResponse : LFResponse
    {
        /// <summary>
        /// Объект списка исполнителей.
        /// </summary>
        [JsonProperty("artists")]
        public LFArtists Data { get; set; }

        /// <summary>
        /// Являются ли данные валидными.
        /// </summary>
        public override bool IsValid()
        {
            return Data != null && Data.IsValid();
        }
    }
}
