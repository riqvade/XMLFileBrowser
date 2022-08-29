using System;
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
        /// Главы
        /// </summary>
        private ObservableCollection<ChapterModel> _chapters { get; set; } = new ObservableCollection<ChapterModel>();

        /// <summary>
        /// Добавляет главы
        /// </summary>
        public void AddChapters(ObservableCollection<ChapterModel> chapters)
        {
            if (chapters != null)
            {
                _chapters = chapters;
            }
            else
            {
                throw new ArgumentNullException(nameof(chapters));
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
