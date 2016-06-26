namespace OneTeam.SDK.VK.Models.Docs
{
    public enum VKDocumentType : byte
    {
        /// <summary>
        /// Значение по умолчанию.
        /// </summary>
        Default = 0,
        /// <summary>
        /// Текстовый документ.
        /// </summary>
        Text,
        /// <summary>
        /// Архив.
        /// </summary>
        Archive,
        /// <summary>
        /// GIF-изображение.
        /// </summary>
        Gif,
        /// <summary>
        /// Изображение.
        /// </summary>
        Image,
        /// <summary>
        /// Аудиозапись.
        /// </summary>
        Audio,
        /// <summary>
        /// Видеозапись.
        /// </summary>
        Video,
        /// <summary>
        /// Электронная книга.
        /// </summary>
        EBook,
        /// <summary>
        /// Неизвестно.
        /// </summary>
        Unknown = 8
    }
}
