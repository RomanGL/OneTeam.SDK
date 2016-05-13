namespace OneTeam.SDK.LastFm.Models.Common
{
    /// <summary>
    /// Реализуют объекты, поддерживающие валидацию своих данных.
    /// </summary>
    public interface ISupportValidation
    {
        /// <summary>
        /// Являются ли данные валидными.
        /// </summary>
        bool IsValid();
    }
}
