using System;
using Newtonsoft.Json;
using OneTeam.SDK.Core.Json;

namespace OneTeam.SDK.VK.Models.Video
{
    /// <summary>
    /// Видеозапись ВКонтакте.
    /// </summary>
    public class VKVideo
    {
        /// <summary>
        /// Идентификатор владельца видеозаписи.
        /// </summary>
        [JsonProperty("owner_id")]
        public long OwnerID { get; set; }
        /// <summary>
        /// Заголовок видеозаписи.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// Описание видеозаписи.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// Длительность видеозаписи.
        /// </summary>
        [JsonProperty("duration")]
        [JsonConverter(typeof(SecondsToTimeSpanConverter))]
        public TimeSpan Duration { get; set; }
        /// <summary>
        /// Ссылка на файл MP4 240p.
        /// </summary>        
        public string URL240 { get; set; }
        /// <summary>
        /// Ссылка на файл MP4 360p.
        /// </summary>
        public string URL360 { get; set; }
        /// <summary>
        /// Ссылка на файл MP4 480p.
        /// </summary>
        public string URL480 { get; set; }
        /// <summary>
        /// Ссылка на файл MP4 720p.
        /// </summary>
        public string URL720 { get; set; }
        /// <summary>
        /// Ссылка на картинку шириной 130 пикс.
        /// </summary>
        [JsonProperty("photo_130")]
        public string Photo130 { get; set; }
        /// <summary>
        /// Ссылка на картинку шириной 320 пикс.
        /// </summary>
        [JsonProperty("photo_320")]
        public string Photo320 { get; set; }
        /// <summary>
        /// Ссылка на картинку шириной 640 пикс.
        /// </summary>
        [JsonProperty("photo_640")]
        public string Photo640 { get; set; }
        /// <summary>
        /// Дата добавления видеозаписи.
        /// </summary>
        [JsonProperty("date")]
        [JsonConverter(typeof(UnixtimeToDateTimeConverter))]
        public DateTime Date { get; set; }
        /// <summary>
        /// Количество просмотров.
        /// </summary>
        [JsonProperty("views")]
        public long ViewsCount { get; set; }
        /// <summary>
        /// Количество комментариев.
        /// </summary>
        [JsonProperty("comments")]
        public long CommentsCount { get; set; }
        /// <summary>
        /// Ссылка на HTML5 проигрыватель.
        /// </summary>
        [JsonProperty("count")]
        public string Player { get; set; }
        /// <summary>
        /// Идентификатор видеозаписи.
        /// </summary>
        [JsonProperty("id")]
        public long ID { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
