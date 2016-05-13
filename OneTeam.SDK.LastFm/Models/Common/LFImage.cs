using Newtonsoft.Json;
using OneTeam.SDK.LastFm.Json;

namespace OneTeam.SDK.LastFm.Models.Common
{
    /// <summary>
    /// Представляет изображение Last.fm.
    /// </summary>
    public class LFImage
    {
        /// <summary>
        /// Ссылка на изображение.
        /// </summary>
        [JsonProperty("#text")]
        public string URL { get; set; }

        /// <summary>
        /// Размер изображения.
        /// </summary>
        [JsonConverter(typeof(LFImageSizeConverter))]
        [JsonProperty("size")]
        public LFImageSize Size { get; set; }
    }
}
