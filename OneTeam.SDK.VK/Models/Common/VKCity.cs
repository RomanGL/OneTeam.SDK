﻿using Newtonsoft.Json;

namespace OneTeam.SDK.VK.Models.Common
{
    /// <summary>
    /// Представляет объект информации о городе ВКонтакте.
    /// </summary>
    public class VKCity
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [JsonProperty("id")]
        public uint ID { get; set; }
        
        /// <summary>
        /// Название.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
