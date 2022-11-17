using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace _6_4_Binding对数据的转换与校验_2_数据转换
{
    internal class CategoryToSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Category category = (Category)value;
            switch (category)
            {
                case Category.Bomber:
                    return @".\Icons\bomber.png";
                case Category.Fighter:
                    return @".\Icons\fighter.png";
                default: return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
