using MVVMSampleAppWpf.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace MVVMSampleAppWpf.Converters
{
    public class ItemPathConverter : IValueConverter
    {
        /// <summary>
        /// SelectedItem -> "path"
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = (DemoItem)value;
            return $"/Views/{item.Name}.xaml";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
