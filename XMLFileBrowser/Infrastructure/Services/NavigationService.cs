using NLog;
using XMLFileBrowser.XMLViewer;

namespace XMLFileBrowser.Infrastructure.Services
{
    /// <summary>
    /// Сервис навигации
    /// </summary>
    public class NavigationService
    {
        /// <summary>
        /// Логгер
        /// </summary>
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Осуществляет переход на страницу XML обозревателя.
        /// </summary>
        public void GoToXMLViewer()
        {
            MainWindow window = (MainWindow)App.Current.MainWindow;
            window.MainFrame.Content = new XMLViewerPage();
            _logger.Trace($"Осуществлен переход на страницу XMLViewerPage");
        }
    }
}