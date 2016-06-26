using Newtonsoft.Json;
using OneTeam.SDK.Core.Json;
using System;

namespace OneTeam.SDK.VK.Models.Docs
{
    /// <summary>
    /// Представляет документ ВКонтакте.
    /// </summary>
    public class VKDocument
    {
        /// <summary>
        /// Идентификатор документа.
        /// </summary>
        [JsonProperty("id")]
        public long ID { get; set; }

        /// <summary>
        /// Идентификатор владельца документа.
        /// </summary>
        [JsonProperty("owner_id")]
        public long OwnerID { get; set; }

        /// <summary>
        /// Название документа.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Размер файла в байтах.
        /// </summary>
        [JsonProperty("size")]
        public ulong Size { get; set; }

        /// <summary>
        /// Расширение файла (например, mp4).
        /// </summary>
        [JsonProperty("ext")]
        public string Extension { get; set; }

        /// <summary>
        /// Ссылка на файл.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Ссылка на фотографию размером 100x75.
        /// </summary>
        [JsonProperty("photo_100")]
        public string Photo100 { get; set; }

        /// <summary>
        /// Ссылка на фотографию размером 130x100.
        /// </summary>
        [JsonProperty("photo_130")]
        public string Photo130 { get; set; }

        /// <summary>
        /// Дата добавления файла.
        /// </summary>
        [JsonProperty("date")]
        [JsonConverter(typeof(UnixtimeToDateTimeConverter))]
        public DateTime Date { get; set; }

        /// <summary>
        /// Тип содержимого файла.
        /// </summary>
        [JsonProperty("type")]
        public VKDocumentType Type { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
