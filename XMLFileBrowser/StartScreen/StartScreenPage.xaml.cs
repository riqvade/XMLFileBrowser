using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;
using XMLFileBrowser.Infrastructure.Services;

namespace XMLFileBrowser.StartScreen
{
    /// <summary>
    /// Логика взаимодействия для SSP.xaml
    /// </summary>
    public partial class StartScreenPage : Page
    {
        public StartScreenPage()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService<StartScreenViewModel>();
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

            if (!string.IsNullOrEmpty(droppedFilenames[0]))
            {
                NavigationService navigationService = App.Current.Services.GetService<NavigationService>();
                navigationService.GoToImageEditor();
            }
        }
    }
}
