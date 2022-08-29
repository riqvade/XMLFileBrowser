using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLFileBrowser.Components
{
    /// <summary>
    /// Осуществляет загрузку XML файла в приложение
    /// </summary>
    public static class XMLLoader
    {
        /// <summary>
        /// Возвращает путь к XML файлу
        /// </summary>
        public static string GetXmlFilePath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Excel Files|*.XML";
            openFileDialog.RestoreDirectory = true;

            string filePath = string.Empty;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;

                return filePath;
            }
            else
            {
                return null;
            }
        }
    }
}
