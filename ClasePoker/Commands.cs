using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClasePoker
{
    public class Commands
    {
        private static RoutedUICommand reparteix;
        private static RoutedUICommand apostaMes;
        private static RoutedUICommand doble;
        private static RoutedUICommand semiDoble;
        private static RoutedUICommand swap;
        private static RoutedUICommand deal;
        static Commands()
        {
            reparteix = new RoutedUICommand(
                "Reparteix", "Reparteix", typeof(Commands));
            doble = new RoutedUICommand(
                "Doble", "Doble", typeof(Commands));
            semiDoble = new RoutedUICommand(
                "SemiDoble", "SemiDoble", typeof (Commands));
            apostaMes = new RoutedUICommand(
                "ApostaMes", "ApostaMes", typeof(Commands));
            swap = new RoutedUICommand(
                "Swap", "Swap", typeof(Commands));
            deal = new RoutedUICommand(
                "Deal", "Deal", typeof(Commands));
        }
        public static RoutedUICommand Reparteix => reparteix;
        public static RoutedUICommand Doble => doble;
        public static RoutedUICommand SemiDoble => semiDoble;
        public static RoutedUICommand ApostaMes => apostaMes;
        public static RoutedUICommand Deal => deal;
        public static RoutedUICommand Swap => swap;
    }
}
