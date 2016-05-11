﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace OneTeam.SDK.VK.Models.Common
{
    /// <summary>
    /// Базовый абстрактный класс спискового ответа ВКонтакте.
    /// </summary>
    public abstract class VKBaseItemsObject<T>
    {
        /// <summary>
        /// Коллекция объектов.
        /// </summary>
        [JsonProperty("items")]
        public List<T> Items { get; set; }
    }
}
