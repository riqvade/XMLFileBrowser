using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
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
        /// Имя файла
        /// </summary>
        public string FileName
        {
            get => _fileName;
            set 
            {
                value = Path.GetFileName(value);
                Set(ref _fileName, value);
            }
        }

        /// <summary>
        /// Имя файла
        /// </summary>
        public Visibility visib { get; set; } = Visibility.Collapsed;

        /// <summary>
        /// Главы
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
            AddFileCommand = new RelayCommand(LoadFile);
            FileName = _fileService.GetFilePath();
            _fileContentService.AddChapters(XMLParser.ParceXMLFile(_fileService.GetFilePath()));
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
        /// Загружает файл
        /// </summary>
        private void LoadFile()
        {
            string filePath = XMLLoader.GetXmlFilePath();
            if (!string.IsNullOrEmpty(filePath))
            {
                Chapters.Clear();
                FileName = filePath;
                _fileContentService.AddChapters(XMLParser.ParceXMLFile(filePath));
                AddChaptersInChapterViewModel();
            }
        }
    }
}
