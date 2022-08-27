using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLFileBrowser.XMLViewer
{
    public class ResourceModel
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
        /// Количество
        /// </summary>
        public string Quantity { get; }

        /// <summary>
        /// Создает экземпляр класса <see cref="ResourceModel"/>
        /// </summary>
        public ResourceModel(string code, string caption, string quantity)
        {
            Code = code;
            Caption = caption;
            Quantity = quantity;
        }
    }
}
