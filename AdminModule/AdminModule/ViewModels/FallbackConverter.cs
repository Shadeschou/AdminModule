using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AdminModule.ViewModels
{
    public class FallbackConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int v = 0; // default if no value provided or value is not convertible to int
            if (value != null)
            {
                var result = int.TryParse(value.ToString(), out v);
            }

            return v;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = string.Empty;
            if (value != null)
            {
                result = value.ToString();
            }

            return result;
        }
    }
}
