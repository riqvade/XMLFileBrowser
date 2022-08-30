using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using XMLFileBrowser.XMLViewer;

namespace XMLFileBrowser.Converters
{
    public class CountPositionsToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Возвращает visibility
        /// </summary>
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibility = Visibility.Collapsed;

            ObservableCollection<Position> positions = value as ObservableCollection<Position>;

            if (positions != null)
            {
                if (positions.Count == 0)
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
