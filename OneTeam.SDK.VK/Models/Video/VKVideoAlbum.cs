using Newtonsoft.Json;

namespace OneTeam.SDK.VK.Models.Video
{
    /// <summary>
    /// Представляет собой альбом видеозаписей ВКонтакте.
    /// </summary>
    public class VKVideoAlbum
    {
        /// <summary>
        /// Идентификатор альбома ВКонтакте.
        /// </summary>
        [JsonProperty("id")]
        public long ID { get; set; }
        /// <summary>
        /// Идентификатор владельца альбома.
        /// </summary>
        [JsonProperty("owner_id")]
        public long OwnerID { get; set; }
        /// <summary>
        /// Название альбома.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
