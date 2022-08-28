using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLFileBrowser.XMLViewer
{
    /// <summary>
    /// Модель Глав
    /// </summary>
    public class ChapterModel
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Caption { get; }

        /// <summary>
        /// Модель позиции
        /// </summary>
        public ObservableCollection<PositionModel> PositionModels { get; }

        /// <summary>
        /// Создает экземпляр класса <see cref="ChapterModel"/>
        /// </summary>
        public ChapterModel(string caption, ObservableCollection<PositionModel> positionModels)
        {
            Caption = caption;
            PositionModels = positionModels;
        }
    }
}
