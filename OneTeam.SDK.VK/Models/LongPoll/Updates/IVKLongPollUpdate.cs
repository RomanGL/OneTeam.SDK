using Newtonsoft.Json;
using OneTeam.SDK.VK.Json;

namespace OneTeam.SDK.VK.Models.LongPoll
{
    /// <summary>
    /// Представляет информацию о событии LongPoll сервера.
    /// </summary>
    [JsonConverter(typeof(VKLongPollUpdateConverter))]
    public interface IVKLongPollUpdate
    {
        /// <summary>
        /// Тип обновления.
        /// </summary>
        VKLongPollUpdateType Type { get; }
    }
}
