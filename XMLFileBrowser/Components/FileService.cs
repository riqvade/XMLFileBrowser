namespace XMLFileBrowser.Components
{
    /// <summary>
    /// Сервис для работы с файлами
    /// </summary>
    public class FileService
    {
        /// <summary>
        /// Путь к файлу
        /// </summary>
        private string FilePath { get; set; }

        /// <summary>
        /// Возвращает путь к файлу
        /// </summary>
        public string GetFilePath()
        {
            return FilePath;
        }

        /// <summary>
        /// Добавляет путь к файлу
        /// </summary>
        public void AddFile(string filePath)
        {
            FilePath = filePath;
        }
    }
}
