using System;
using System.Globalization;
using System.Windows.Data;

namespace MongoDBDemo.Converters
{
    internal class TextIsEnterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = (string)value;
            var res = text.StartsWith(@"/h1");
            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
