using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NLog;
using System.IO;
using System.Windows.Input;
using XMLFileBrowser.Components;
using XMLFileBrowser.Infrastructure.Services;

namespace XMLFileBrowser.StartScreen
{
    /// <summary>
    /// Экземпляр ViewModel стартовой страницы
    /// </summary>
    class StartScreenViewModel : ViewModelBase
    {
        /// <summary>
        /// Логгер
        /// </summary>
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Сервис навигации
        /// </summary>
        private readonly NavigationService _navigationService;

        /// <summary>
        /// Сервис файлов
        /// </summary>
        private readonly FileService _fileService;

        /// <summary>
        /// Команда для загрузки пути к XML файлу
        /// </summary>
        public RelayCommand AddFileCommand { get; }

        /// <summary>
        /// Создает экземпляр класса <see cref="StartScreenViewModel"/>
        /// </summary>
        public StartScreenViewModel(NavigationService navigationService, FileService fileService)
        {
            _navigationService = navigationService;
            _fileService = fileService;
            AddFileCommand = new RelayCommand(LoadImagesAndGoToXMLViewer);
        }

        /// <summary>
        /// Загружает путь к XML файлу и осуществляет переход на страницу XML обозревателя.
        /// </summary>
        private void LoadImagesAndGoToXMLViewer()
        {
            if (_fileService.SelectInputFile())
            {
                _navigationService.GoToXMLViewer();
            }
        }
    }
}
