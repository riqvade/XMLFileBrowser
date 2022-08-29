using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using XMLFileBrowser.Components;
using XMLFileBrowser.Infrastructure.Services;
using XMLFileBrowser.StartScreen;
using XMLFileBrowser.XMLViewer;

namespace XMLFileBrowser
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Получает текущий используемый экземпляр <see cref="App"/>
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Получает экземпляр <see cref="IServiceProvider"/> для разрешения служб приложений.
        /// </summary>
        public IServiceProvider Services { get; private set; }

        /// <summary>
        /// Вызывается при обычном запуске приложения пользователем.
        /// </summary>
        protected override void OnStartup(StartupEventArgs e)
        {
            Services = ConfigureServices();
        }

        /// <summary>
        /// Настраивает сервисы для приложения.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddTransient<StartScreenViewModel>()
                .AddSingleton<NavigationService>()
                .AddSingleton<FileService>()
                .AddSingleton<FileContentService>()
                .AddSingleton<XMLViewerViewModel>()
                .BuildServiceProvider();
        }
    }
}
