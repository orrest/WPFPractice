using System;
using System.Globalization;
using System.Windows.Data;

namespace _11_5_Style_demo4_DataTrigger;

public class L2BConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        int textLength = (int)value;
        return textLength < 6 ? true : false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}