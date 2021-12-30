using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MgSoftDev.Controls.WPF.Helpers.Converters
{
    internal class BoolToVisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = (bool)(value ?? false);
            return v ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
