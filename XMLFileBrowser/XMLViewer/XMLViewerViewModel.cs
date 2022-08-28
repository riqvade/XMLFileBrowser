using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLFileBrowser.Components;

namespace XMLFileBrowser.XMLViewer
{
    public class XMLViewerViewModel
    {

        /// <summary>
        /// Сервис для работы с содержимым файла
        /// </summary>
        private readonly FileContentService _fileContentService;

        /// <summary>
        /// Список изображений
        /// </summary>
        public ObservableCollection<ChapterViewModel> Chapters { get; } = new ObservableCollection<ChapterViewModel>();


        public XMLViewerViewModel(FileContentService fileContentService)
        {
            _fileContentService = fileContentService;
            AddChaptersInChapterViewModel();
        }

        /// <summary>
        /// Загружает изображения
        /// </summary>
        private async void LoadFiles()
        {
            //IReadOnlyCollection<StorageFile> storageFiles = await ImagesLoader.GetImageFiles();

            //if (storageFiles.Count > 0)
            //{
            //    await _imageService.AddImagesAsync(storageFiles);
            //}

            //AddImagesInImageViewModel();
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

            _fileContentService.ClearChapters();
        }
    }
}
