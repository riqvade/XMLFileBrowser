using System.Collections.ObjectModel;

namespace XMLFileBrowser.XMLViewer
{
    /// <summary>
    /// Позиция
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Номер позиции
        /// </summary>
        public string Number { get; set; }

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

        public ObservableCollection<Resource> Resources { get; set; }

        /// <summary>
        /// Создает экземпляр класса <see cref="Position"/>
        /// </summary>
        public Position(string code, string caption, string units, string quantity, ObservableCollection<Resource> resources, string number)
        {
            Code = code;
            Caption = caption;
            Units = units;
            Quantity = quantity;
            Resources = resources;
            Number = number;
        }
    }
}
