using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLFileBrowser.XMLViewer
{
    public class PositionModel
    {

        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Заголовок
        /// </summary>
        public string Caption { get; }

        /// <summary>
        /// Единицы
        /// </summary>
        public string Units { get; }

        /// <summary>
        /// Количество
        /// </summary>
        public string Quantity { get; }

        public List<ResourceModel> ResourcesModels { get; }

        /// <summary>
        /// Создает экземпляр класса <see cref="PositionModel"/>
        /// </summary>
        public PositionModel(string code, string caption, string units, string quantity, List<ResourceModel> resourceModels)
        {
            Code = code;
            Caption = caption;
            Units = units;
            Quantity = quantity;
            ResourcesModels = resourceModels;
        }
    }
}
