using System;
using System.Collections.Generic;
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
        public string Caption { get; }

        /// <summary>
        /// Модель позиции
        /// </summary>
        public List<PositionModel> PositionModels { get; }

        /// <summary>
        /// Создает экземпляр класса <see cref="ChapterModel"/>
        /// </summary>
        public ChapterModel(string caption, List<PositionModel> positionModels)
        {
            Caption = caption;
            PositionModels = positionModels;
        }
    }
}
