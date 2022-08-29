using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace XMLFileBrowser.XMLViewer
{
    /// <summary>
    /// Логика взаимодействия для XMLViewerPage.xaml
    /// </summary>
    public partial class XMLViewerPage : Page
    {
        /// <summary>
        /// Создает экземпляр класса <see cref="XMLViewerPage"/>
        /// </summary>
        public XMLViewerPage()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService<XMLViewerViewModel>();
        }

        /// <summary>
        /// Показывает или скрывает подразделы глав
        /// </summary>
        private void ShowOrHideDetails(object sender, RoutedEventArgs e)
        {
            for (Visual vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
            {
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    row.DetailsVisibility = row.DetailsVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;

                    break;
                }
            }
            for (Visual vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
            {
                if (vis is Button)
                {
                    var button = (Button)vis;
                    button.Content = button.Content.Equals("+") ? "-" : "+";

                    break;
                }
            }
        }
    }
}
