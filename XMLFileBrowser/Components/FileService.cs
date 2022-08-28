using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLFileBrowser.Components
{
    /// <summary>
    /// Сервис для работы с файлами
    /// </summary>
    public class FileService
    {
        private string FilePath { get; set; }

        public void AddFile(string filePath)
        {
            FilePath = filePath;
        }

    }
}
