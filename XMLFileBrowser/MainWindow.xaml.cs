using System;
using System.Collections.Generic;
using System.Windows;
using System.Xml;
using XMLFileBrowser.Components;
using XMLFileBrowser.StartScreen;
using XMLFileBrowser.XMLViewer;

namespace XMLFileBrowser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new StartScreenPage();

            //XMLParser.ParceXML();
        }

      
    }
}
