﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XMLFileBrowser.Components;

namespace XMLFileBrowser.StartScreen
{
    class StartScreenViewModel : ViewModelBase
    {
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
                    LoadImagesAndGoToImageEditor();
                });
            }
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="StartScreenViewModel"/>
        /// </summary>
        public StartScreenViewModel()
        {
            AddImagesCommand = new RelayCommand(LoadImagesAndGoToImageEditor);
        }

        /// <summary>
        /// Загружает путь к XML файлу.
        /// </summary>
        private void LoadImagesAndGoToImageEditor()
        {
            string filePath = XMLLoader.GetXmlFilePath();

            if (!string.IsNullOrEmpty(filePath))
            {
                //await _imageService.AddImagesAsync(storageFiles);
                //_navigationService.GoToImageEditor();
            }
        }
    }
}
