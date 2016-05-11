using Newtonsoft.Json;
using OneTeam.SDK.VK.Models.Common;
using OneTeam.SDK.VK.Models.Groups;
using OneTeam.SDK.VK.Models.Users;
using System.Collections.Generic;

namespace OneTeam.SDK.VK.Models.Newsfeed
{
    /// <summary>
    /// Ответ сервера ВКонтакте на вызов метода newsfeed.get.
    /// </summary>
    public sealed class VKNewsfeedGetResponse : VKBaseItemsObject<VKNewsfeedItem>
    {
        /// <summary>
        /// Информация о пользователях, которые
        /// находятся в списке новостей.
        /// </summary>
        [JsonProperty("profiles")]
        public List<VKUser> Profiles { get; set; }

        /// <summary>
        /// Информация о группах, которые находятся в списке новостей.
        /// </summary>
        [JsonProperty("groups")]
        public List<VKGroup> Groups { get; set; }

        /// <summary>
        /// From, который необходимо передать, для того, 
        /// чтобы получить следующую часть новостей.
        /// </summary>
        [JsonProperty("next_from")]
        public string NextFrom { get; set; }
    }
}
