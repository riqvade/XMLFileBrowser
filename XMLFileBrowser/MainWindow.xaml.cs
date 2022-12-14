using System;
using System.Data;
using System.Globalization;
using System.Windows;
using XMLFileBrowser.Helpers;
using XMLFileBrowser.StartScreen;

namespace XMLFileBrowser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Создает экземпляр класса <see cref="MainWindow"/>
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new StartScreenPage();
        }
    }
}
