using System;
using System.Globalization;
using System.Windows.Data;

namespace ClickerGame.View
{
    public class DecimalToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal.TryParse(value.ToString(), out var x);
            return (int)x;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
