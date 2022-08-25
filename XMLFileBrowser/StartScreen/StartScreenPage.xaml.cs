using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace XMLFileBrowser.StartScreen
{
    /// <summary>
    /// Логика взаимодействия для StartScreenPage.xaml
    /// </summary>
    public partial class StartScreenPage : Window
    {

        public StartScreenPage()
        {
            InitializeComponent();
            DataContext = new StartScreenViewModel();
        }

        /// <summary>
        /// Обрабатывает событие перетаскивания файлов в область загрузки
        /// </summary>
        private void DragDropArea_DragOver(object sender, DragEventArgs e)
        {
            bool dropEnabled = true;
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                string[] filenames =
                                 e.Data.GetData(DataFormats.FileDrop, true) as string[];

                foreach (string filename in filenames)
                {
                    if (System.IO.Path.GetExtension(filename).ToUpperInvariant() != ".XML")
                    {
                        dropEnabled = false;
                        break;
                    }
                }
            }
            else
            {
                dropEnabled = false;
            }

            if (!dropEnabled)
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
        }

        /// <summary>
        /// Обрабатывает событие сбрасывания файлов в область загрузки
        /// </summary>
        private void DragDropArea_Drop(object sender, DragEventArgs e)
        {
            string[] droppedFilenames =
                        e.Data.GetData(DataFormats.FileDrop, true) as string[];
        }
    }
}