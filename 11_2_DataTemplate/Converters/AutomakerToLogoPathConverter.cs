using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace _11_2_DataTemplate;

public class AutomakerToLogoPathConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string uriStr = string.Format(@"/Images/{0}.jpg", (string)value);
        return new BitmapImage(new Uri(uriStr, UriKind.Relative));
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}