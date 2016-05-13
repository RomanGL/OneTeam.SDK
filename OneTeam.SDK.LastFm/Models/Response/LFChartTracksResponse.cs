using Newtonsoft.Json;
using OneTeam.SDK.LastFm.Models.Audio;

namespace OneTeam.SDK.LastFm.Models.Response
{
    /// <summary>
    /// Представляет ответ сервера Last.fm на запрос чартов композиций.
    /// </summary>
    public class LFChartTracksResponse : LFResponse
    {      
        /// <summary>
        /// Объект списка треков.
        /// </summary>
        [JsonProperty("tracks")]
        public LFTracks Items { get; set; }

        /// <summary>
        /// Являются ли данные валидными.
        /// </summary>
        public override bool IsValid()
        {
            return Items != null && Items.IsValid();
        }
    }
}
