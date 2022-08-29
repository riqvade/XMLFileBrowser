using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private ObservableCollection<ChapterModel> _chapterModels { get; set; } = new ObservableCollection<ChapterModel>();

        /// <summary>
        /// Добавляет главы
        /// </summary>
        public void AddChapters(ObservableCollection<ChapterModel> chapters)
        {
            if (chapters != null)
            {
                foreach (ChapterModel chapter in chapters)
                {
                    _chapterModels = chapters;
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(chapters));
            }
        }

        /// <summary>
        /// Возвращает главы
        /// </summary>
        public IReadOnlyCollection<ChapterModel> GetChapters()
        {
            return _chapterModels;
        }

        /// <summary>
        /// Удаляет главы
        /// </summary>
        public void ClearChapters()
        {
            _chapterModels.Clear();
        }
    }
}
