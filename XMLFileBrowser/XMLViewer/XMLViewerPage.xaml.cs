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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XMLFileBrowser.XMLViewer
{
    /// <summary>
    /// Логика взаимодействия для XMLViewerPage.xaml
    /// </summary>
    public partial class XMLViewerPage : Page
    {

        public Person[] People { get; } = new Person[2];

        public XMLViewerPage()
        {
            InitializeComponent();
            DataContext = this;

            People[0] = new Person(1, "Вася", 24, new PersonTasks[]
            {
                new PersonTasks(11, "Помыть полы", "Очень грязные!", new PersonSubTasks[]
                {
                    new PersonSubTasks(01, "на первый раз", "с хлоркой"),
                    new PersonSubTasks(02, "на второй раз", "с порошком"),
                }),
                new PersonTasks(12, "Перекусить", "Голоден..." , new PersonSubTasks[]
                {
                    new PersonSubTasks(01, "суп", "с хлебом"),
                    new PersonSubTasks(02, "пирожки", "запить чаем"),
                }),
            });

            People[1] = new Person(2, "Таня", 16, new PersonTasks[]
            {
                new PersonTasks(21, "Цветы", "Полить, протереть, удобрить", new PersonSubTasks[]
                {
                    new PersonSubTasks(01, "на первый раз", "с хлоркой"),
                    new PersonSubTasks(02, "на второй раз", "с порошком"),
                }),
                new PersonTasks(22, "Собака", "Погулять, покормить", new PersonSubTasks[]
                {
                    new PersonSubTasks(01, "во дворе", "с пакетом..."),
                    new PersonSubTasks(02, "дома", "без пакета"),
                }),
            });
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

                if (vis is Button)
                {
                    var button = (Button)vis;
                    button.Content = button.Content.Equals("+") ? "-" : "+";
                }

            }
        }
    }
}
