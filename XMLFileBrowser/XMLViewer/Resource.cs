namespace XMLFileBrowser.XMLViewer
{
    /// <summary>
    /// Ресурс
    /// </summary>
    public class Resource
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
        /// Количество
        /// </summary>
        public string Quantity { get; set; }

        /// <summary>
        /// Создает экземпляр класса <see cref="Resource"/>
        /// </summary>
        public Resource(string code, string caption, string quantity)
        {
            Code = code;
            Caption = caption;
            Quantity = quantity;
        }
    }
}
