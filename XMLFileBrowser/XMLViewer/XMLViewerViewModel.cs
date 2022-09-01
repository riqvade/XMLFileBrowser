using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
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
        private string _fileName;

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
        /// Главы
        /// </summary>
        public ObservableCollection<ChapterViewModel> Chapters { get; set; } = new ObservableCollection<ChapterViewModel>();

        /// <summary>
        /// Команда для загрузки файла
        /// </summary>
        public RelayCommand AddFileCommand { get; }

        /// <summary>
        /// Команда для экспорта данных в excel
        /// </summary>
        public RelayCommand ExportToExcelCommand { get; }

        /// <summary>
        /// Создает экземпляр класса <see cref="XMLViewerViewModel"/>
        /// </summary>
        public XMLViewerViewModel(FileContentService fileContentService, FileService fileService)
        {
            _fileContentService = fileContentService;
            _fileService = fileService;
            AddFileCommand = new RelayCommand(LoadFile);
            ExportToExcelCommand = new RelayCommand(SaveFile);
            FileName = _fileService.GetInputFilePath();
            if (_fileContentService.AddChapters(XMLParser.ParceXMLFile(_fileService.GetInputFilePath())))
            {
                AddChaptersInChapterViewModel();
            }
        }

        /// <summary>
        /// Добавляет загруженные данные во View
        /// </summary>
        private void AddChaptersInChapterViewModel()
        {
            foreach (ChapterModel item in _fileContentService.GetChapters())
            {
                Chapters.Add(new ChapterViewModel(item));
            }
        }

        /// <summary>
        /// Загружает файл
        /// </summary>
        private void LoadFile()
        {
            if (_fileService.SelectInputFile() == true)
            {
                Chapters.Clear();
                _fileContentService.ClearChapters();
                FileName = _fileService.GetInputFilePath();

                if(_fileContentService.AddChapters(XMLParser.ParceXMLFile(_fileService.GetInputFilePath())))
                {
                    AddChaptersInChapterViewModel();
                }
            }
        }

        private void SaveFile()
        {
            if (_fileService.SelectExportFolder() == true)
            {
                ExportManager.ExportDataToExcel(_fileService.GetExportFilePath());
            }
        }
    }
}
