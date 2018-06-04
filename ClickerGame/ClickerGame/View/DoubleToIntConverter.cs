using System;
using System.Globalization;
using System.Windows.Data;

namespace ClickerGame.View
{
    public class DoubleToIntConverter : IValueConverter
    {
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            Double x;
            Double.TryParse(value.ToString(), out x);
            return (Int32)x;
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}