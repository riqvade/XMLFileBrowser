using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using XMLFileBrowser.Components;

namespace XMLFileBrowser.XMLViewer
{
    /// <summary>
    /// Логика взаимодействия для XMLViewerPage.xaml
    /// </summary>
    public partial class XMLViewerPage : Page
    {
        /// <summary>
        /// Главы
        /// </summary>
        public ObservableCollection<ChapterModel> ChapterModels { get; } = new ObservableCollection<ChapterModel>();

        public XMLViewerPage()
        {
            InitializeComponent();
            DataContext = this;

            ChapterModels = XMLParser.ParceXML();
        }

        private void ShowHideDetails(object sender, RoutedEventArgs e)
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
