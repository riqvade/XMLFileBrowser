using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using XMLFileBrowser.XMLViewer;

namespace XMLFileBrowser.Converters
{
    /// <summary>
    /// Конвертер CountResources в Visibility
    /// </summary>
    public class CountResourcesToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Возвращает visibility
        /// </summary>
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibility = Visibility.Collapsed;

            ObservableCollection<Resource> resources = value as ObservableCollection<Resource>;

            if (resources != null)
            {
                if (resources.Count == 0)
                {
                    visibility = Visibility.Collapsed;
                }
                else
                {
                    visibility = Visibility.Visible;
                }
            }
            return visibility;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
