using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Data;

namespace _2024_02_24_Kepnezegeto
{
    class CountConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int photosCount = (int)value;
            if (photosCount != 0)
                return string.Format($"{photosCount} db Fénykép");
            return "Nincs fénykép az adott mappában";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
