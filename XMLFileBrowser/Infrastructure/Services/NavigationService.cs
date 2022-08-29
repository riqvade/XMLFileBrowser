using XMLFileBrowser.XMLViewer;

namespace XMLFileBrowser.Infrastructure.Services
{
    /// <summary>
    /// Сервис навигации
    /// </summary>
    public class NavigationService
    {
        /// <summary>
        /// Осуществляет переход на страницу XML обозревателя.
        /// </summary>
        public void GoToXMLViewer()
        {
            MainWindow window = (MainWindow)App.Current.MainWindow;
            window.MainFrame.Content = new XMLViewerPage();
        }
    }
}