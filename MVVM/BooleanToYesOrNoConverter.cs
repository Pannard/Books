using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Books.MVVM
{
    internal class BooleanToYesOrNoConverter: IValueConverter
    {
        public BooleanToYesOrNoConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = System.Convert.ToBoolean(value, CultureInfo.InvariantCulture);

            return boolValue ? "Oui" : "Non";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
