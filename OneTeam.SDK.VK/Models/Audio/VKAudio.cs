using System;
using Newtonsoft.Json;
using OneTeam.SDK.VK.Models.Common;
using OneTeam.SDK.Core.Json;

namespace OneTeam.SDK.VK.Models.Audio
{
    /// <summary>
    /// Аудиозапись ВКонтакте.
    /// </summary>
    public sealed class VKAudio
    {
        /// <summary>
        /// Идентификатор аудиозаписи.
        /// </summary>
        [JsonProperty("id")]
        public long ID { get; set; }

        /// <summary>
        /// Идентификатор владельца аудиозаписи.
        /// </summary>
        [JsonProperty("owner_id")]
        public long OwnerID { get; set; }

        /// <summary>
        /// Исполнитель аудиозаписи.
        /// </summary>
        [JsonProperty("artist")]
        public string Artist { get; set; }

        /// <summary>
        /// Заголовок аудиозаписи.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Длительность аудиозаписи.
        /// </summary>
        [JsonProperty("duration")]
        [JsonConverter(typeof(SecondsToTimeSpanConverter))]
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Ссылка на MP3-файл аудиозаписи.
        /// </summary>
        [JsonProperty("url")]
        public string Source { get; set; }

        /// <summary>
        /// Идентификатор текста аудиозаписи.
        /// </summary>
        [JsonProperty("lyrics_id")]
        public long LyricsID { get; set; }

        /// <summary>
        /// Идентификатор альбома, в котором находится аудиозапись.
        /// </summary>
        [JsonProperty("album_id")]
        public long AlbumID { get; set; }

        /// <summary>
        /// Жанр аудиозаписи.
        /// </summary>
        [JsonProperty("genre_id")]
        public VKAudioGenre Genre { get; set; }

        /// <summary>
        /// Возвращает тип медиаэлемента ВКонтакте.
        /// </summary>
        [JsonProperty("type")]
        public VKMediaType Type { get { return VKMediaType.Audio; } }

        public override string ToString()
        {
            return $"{Artist} - {Title}";
        }
    }
}