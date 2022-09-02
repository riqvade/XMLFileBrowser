using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using XMLFileBrowser.XMLViewer;

namespace XMLFileBrowser.Converters
{
    internal class CountChaptersToEnabledConverter : IValueConverter
    {
        /// <summary>
        /// Конвертирует колличество прочитанных элементов chapters в bool
        /// </summary>
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isEnabled = false;

            ObservableCollection<ChapterViewModel> chapters = value as ObservableCollection<ChapterViewModel>;

            if (chapters.Count == 0 || chapters == null)
            {
                isEnabled = false;
            }
            else
            {
                isEnabled = true;
            }

            return isEnabled;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
