using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLFileBrowser.Components;

namespace XMLFileBrowser.XMLViewer
{
    /// <summary>
    /// Экземпляр ViewModel страницы обозревателя
    /// </summary>
    public class XMLViewerViewModel : ViewModelBase
    {
        /// <summary>
        /// Имя файла
        /// </summary>
        public string _fileName;

        /// <summary>
        /// Сервис для работы с содержимым файла
        /// </summary>
        private readonly FileContentService _fileContentService;

        /// <summary>
        /// Сервис файлов
        /// </summary>
        private readonly FileService _fileService;

        /// <summary>
        /// Сервис файлов
        /// </summary>
        public string FileName
        {
            get => _fileName;
            set => Set(ref _fileName, value);
        }

        /// <summary>
        /// Список изображений
        /// </summary>
        public ObservableCollection<ChapterModel> Chapters { get; set; } = new ObservableCollection<ChapterModel>();

        /// <summary>
        /// Команда для загрузки файла
        /// </summary>
        public RelayCommand AddFileCommand { get; }

        /// <summary>
        /// Создает экземпляр класса <see cref="XMLViewerViewModel"/>
        /// </summary>
        public XMLViewerViewModel(FileContentService fileContentService, FileService fileService)
        {
            _fileContentService = fileContentService;
            _fileService = fileService;
            AddFileCommand = new RelayCommand(LoadFiles);
            FileName = _fileService.GetFilePath();
            _fileContentService.AddChapters(XMLParser.ParceXML(FileName));
            AddChaptersInChapterViewModel();
        }

        /// <summary>
        /// Добавляет загруженные данные во View
        /// </summary>
        private void AddChaptersInChapterViewModel()
        {
            foreach (ChapterModel item in _fileContentService.GetChapters())
            {
                Chapters.Add(item);
            }

            _fileContentService.ClearChapters();
        }

        /// <summary>
        /// Загружает изображения
        /// </summary>
        private void LoadFiles()
        {
            string filePath = XMLLoader.GetXmlFilePath();
            if (!string.IsNullOrEmpty(filePath))
            {
                Chapters.Clear();
                FileName = filePath;
                _fileContentService.AddChapters(XMLParser.ParceXML(filePath));
                AddChaptersInChapterViewModel();
            }
        }
    }
}
