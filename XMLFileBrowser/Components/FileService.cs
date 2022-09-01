using System.IO;
using System.Windows.Forms;

namespace XMLFileBrowser.Components
{
    /// <summary>
    /// Сервис для работы с файлами
    /// </summary>
    public class FileService
    {
        /// <summary>
        /// Путь к входному файлу
        /// </summary>
        private string InputFilePath { get; set; }

        /// <summary>
        /// Путь к экспортному файлу
        /// </summary>
        private string ExportFilePath { get; set; }

        /// <summary>
        /// Возвращает путь к входному файлу
        /// </summary>
        public string GetInputFilePath()
        {
            return InputFilePath;
        }

        /// <summary>
        /// Возвращает путь к входному файлу
        /// </summary>
        public string GetExportFilePath()
        {
            return ExportFilePath;
        }

        /// <summary>
        /// Добавляет путь к входному файлу
        /// </summary>
        public void AddInputFilePath(string filePath)
        {
            InputFilePath = filePath;
        }

        /// <summary>
        /// Добавляет путь к входному файлу
        /// </summary>
        public void AddExportFilePath(string exportFilePath)
        {
            ExportFilePath = exportFilePath;
        }

        /// <summary>
        /// Осуществляет выбор входного файла
        /// </summary>
        public bool SelectInputFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Excel Files|*.XML";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                InputFilePath = openFileDialog.FileName;

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Осуществляет выбор папки экспорта
        /// </summary>
        public bool SelectExportFolder()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Filter = "Excel Files|*.xlsx;";
            saveFileDialog.FileName = Path.GetFileNameWithoutExtension(InputFilePath);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportFilePath = saveFileDialog.FileName;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
