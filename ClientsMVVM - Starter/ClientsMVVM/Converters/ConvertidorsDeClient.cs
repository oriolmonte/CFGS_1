using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ClientsMVVM.Converters
{
    public class ClientColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Decimal? valor = (Decimal?)value;
            if (valor == null)
                return Brushes.Black;
            else
            {
                if(valor<0)
                    return Brushes.Red;
                else 
                    return Brushes.Black;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ClientGruixConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Decimal? valor = (Decimal?)value;
            if (valor == null)
                return 2;
            else
            {
                if (valor < 0)
                    return 5;
                else
                    return 2;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
