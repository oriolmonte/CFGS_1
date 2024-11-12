using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClasseDimartsAccions
{
    public class CommandsEditor
    {
        private static RoutedUICommand augmentaMida;
        private static RoutedUICommand disminueixMida;

        static CommandsEditor()
        {
            augmentaMida = new RoutedUICommand(
                "Augmenta mida", "AugmentaMida", typeof(CommandsEditor));
            disminueixMida = new RoutedUICommand(
                "disminueix mida", "DisminueixMida", typeof(CommandsEditor));
        }

        public static RoutedUICommand AugmentaMida => augmentaMida;

        public static RoutedUICommand DisminueixMida => disminueixMida;
    }
}
