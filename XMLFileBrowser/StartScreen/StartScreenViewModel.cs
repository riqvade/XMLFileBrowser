using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// Сервис навигации
        /// </summary>
        private readonly NavigationService _navigationService;

        /// <summary>
        /// Сервис навигации
        /// </summary>
        private readonly FileService _fileService;

        /// <summary>
        /// Команда для загрузки пути к XML файлу
        /// </summary>
        public RelayCommand AddImagesCommand { get; }

        /// <summary>
        /// Открывает документ и отображает его свойства
        /// </summary>
        public ICommand SelectFilesCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    LoadImagesAndGoToXMLViewer();
                });
            }
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="StartScreenViewModel"/>
        /// </summary>
        public StartScreenViewModel(NavigationService navigationService, FileService fileService)
        {
            _navigationService = navigationService;
            _fileService = fileService;
            AddImagesCommand = new RelayCommand(LoadImagesAndGoToXMLViewer);
        }

        /// <summary>
        /// Загружает путь к XML файлу и осуществляет переход на страницу XML обозревателя.
        /// </summary>
        private void LoadImagesAndGoToXMLViewer()
        {
            string filePath = XMLLoader.GetXmlFilePath();

            if (!string.IsNullOrEmpty(filePath))
            {
                _fileService.AddFile(filePath);
                _navigationService.GoToXMLViewer();
            }
        }
    }
}
