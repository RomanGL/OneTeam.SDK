using Newtonsoft.Json;

namespace OneTeam.SDK.VK.Models.Audio
{
    /// <summary>
    /// Представляет собой альбом аудиозаписей ВКонтакте.
    /// </summary>
    public class VKAudioAlbum
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

        public override string ToString()
        {
            return Title;
        }
    }
}
