using NLog;
using System.Collections.ObjectModel;
using XMLFileBrowser.XMLViewer;

namespace XMLFileBrowser.Components
{
    /// <summary>
    /// Сервис для работы с содержимым файла
    /// </summary>
    public class FileContentService
    {
        /// <summary>
        /// Логгер
        /// </summary>
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Главы
        /// </summary>
        private ObservableCollection<ChapterModel> _chapters { get; set; } = new ObservableCollection<ChapterModel>();

        /// <summary>
        /// Добавляет главы
        /// </summary>
        public bool AddChapters(ObservableCollection<ChapterModel> chapters)
        {
            if (chapters != null)
            {
                _chapters = chapters;
                _logger.Trace("Добавлены главы");

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Возвращает главы
        /// </summary>
        public ObservableCollection<ChapterModel> GetChapters()
        {
            return _chapters;
        }

        /// <summary>
        /// Удаляет главы
        /// </summary>
        public void ClearChapters()
        {
            _chapters.Clear();
        }
    }
}
