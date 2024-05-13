using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace _2024_02_24_Kepnezegeto
{
    class MonthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime currentDate = (DateTime)value;
            //MMMM - hónap névvel, MMM - hónap rövidítéssel, MM - számmal, M - teljes dátummal ctrl+space az összes lehetőséghez
            return currentDate.ToString("MMMM");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
