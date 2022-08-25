using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using XMLFileBrowser.StartScreen;

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
            window.MainFrame.Content = new Page2();
        }

        #endregion Public Methods
    }
}