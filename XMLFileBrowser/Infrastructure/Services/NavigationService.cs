using XMLFileBrowser.XMLViewer;

namespace XMLFileBrowser.Infrastructure.Services
{
    public class NavigationService
    {
        #region Public Methods

        /// <summary>
        /// Осуществляет переход на страницу изменения изображений
        /// </summary>
        public void GoToImageEditor()
        {
            MainWindow window = (MainWindow)App.Current.MainWindow;
            window.MainFrame.Content = new XMLViewerPage();
        }

        #endregion Public Methods
    }
}