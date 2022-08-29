using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLFileBrowser.XMLViewer
{
    /// <summary>
    /// Модель позиций
    /// </summary>
    public class PositionModel
    {

        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Единицы
        /// </summary>
        public string Units { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public string Quantity { get; set; }

        public ObservableCollection<ResourceModel> ResourcesModels { get; set; }

        /// <summary>
        /// Создает экземпляр класса <see cref="PositionModel"/>
        /// </summary>
        public PositionModel(string code, string caption, string units, string quantity, ObservableCollection<ResourceModel> resourceModels)
        {
            Code = code;
            Caption = caption;
            Units = units;
            Quantity = quantity;
            ResourcesModels = resourceModels;
        }
    }
}
