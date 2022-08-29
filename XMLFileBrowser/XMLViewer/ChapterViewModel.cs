using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLFileBrowser.XMLViewer
{
    /// <summary>
    /// Представляет ViewModel главы
    /// </summary>
    public class ChapterViewModel
    {
        /// <summary>
        /// Модель главы
        /// </summary>
        public ChapterModel ChapterModel { get; set; }

        /// <summary>
        /// Создает экземпляр класса <see cref="ChapterViewModel"/>
        /// </summary>
        public ChapterViewModel(ChapterModel chapterModel) => ChapterModel = chapterModel;
    }
}