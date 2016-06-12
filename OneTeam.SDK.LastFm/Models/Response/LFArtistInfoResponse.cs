using Newtonsoft.Json;
using OneTeam.SDK.LastFm.Models.Audio;

namespace OneTeam.SDK.LastFm.Models.Response
{
    /// <summary>
    /// Представляет ответ сервиса на запрос информации об исполнителе.
    /// </summary>
    public class LFArtistInfoResponse : LFResponse
    {
        /// <summary>
        /// Информация об исполнителе.
        /// </summary>
        [JsonProperty("artist")]
        public LFArtistExtended Artist { get; set; }

        /// <summary>
        /// Являются ли данные валидными.
        /// </summary>
        public override bool IsValid()
        {
            return Artist != null;
        }
    }
}
