using RPS.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using static RPS.ViewModel.JugadorViewmodel;

namespace RPS.Converters
{
    public class MainWindowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Gamestate? valor = (Gamestate?)value;
            Gamestate? parametre = (Gamestate?)parameter;
            Visibility resultat = Visibility.Collapsed;
            if(valor != null && parametre != null)
            {
                if(valor == parametre)
                    resultat = Visibility.Visible;
            }
            return resultat;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class WinConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GameResult? valor = (GameResult)value;
            string result = "";
            if(valor == GameResult.Tie) {
                result = "Tied!";
            }
            else if (valor==GameResult.Win)
            {
                result = "You Won!";
            }
            else
            {
                result = "You Lose...";
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
