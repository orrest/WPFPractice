using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace _6_5_MultiBinding
{
    internal class LogonMultiBindingConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!values.Cast<string>().Any(text => string.IsNullOrEmpty(text)) &&
                values[0].ToString() == values[1].ToString() &&
                values[2].ToString() == values[3].ToString()
            ) {
                return true;
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}