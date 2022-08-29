using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLFileBrowser.XMLViewer
{
    /// <summary>
    /// Модель Главы
    /// </summary>
    public class ChapterModel
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Позиции
        /// </summary>
        public ObservableCollection<Position> Positions { get; set; }

        /// <summary>
        /// Создает экземпляр класса <see cref="ChapterModel"/>
        /// </summary>
        public ChapterModel(string caption, ObservableCollection<Position> positions)
        {
            Caption = caption;
            Positions = positions;
        }
    }
}
