using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Animacions
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCreix_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animacioAmplada = new DoubleAnimation();
            ////DESDE/0
            //animacioAmplada.From = 0;
            ////SUMAR LA DIFERENCIA DEL FROM AL TO
            animacioAmplada.From = 0;
            //animacioAmplada.To = 30;
            ////ES EL QUE HO FA
            //animacioAmplada.IsAdditive = true;
            ////ORIGINAL/FROM A 300
            animacioAmplada.To = 300;
            ////+30
            //animacioAmplada.By = 30;
            //animacioAmplada.AutoReverse = true;
            //animacioAmplada.RepeatBehavior = new RepeatBehavior(TimeSpan.FromSeconds(100));
            //animacioAmplada.RepeatBehavior = RepeatBehavior.Forever;

            animacioAmplada.Duration = TimeSpan.FromSeconds(1);
            btnCreix.BeginAnimation(Button.WidthProperty, animacioAmplada);
        }

        private void cmdRedueix_Click(object sender, RoutedEventArgs e)
        {
            //RECORDA ELS VALORS ORIGINALS.
            //FROM I TO PER INTERPOLAR FINS A AQUELL LLOC
            //SI NO S'ESPECIFICA ÉS L'ORIGINAL!
            DoubleAnimation animacioAmplada = new DoubleAnimation();
            animacioAmplada.Duration = TimeSpan.FromSeconds(2);
            btnCreix.BeginAnimation(Button.WidthProperty, animacioAmplada);
        }

        private void btnCreixIncrementalment_Click(object sender, RoutedEventArgs e)
        {
        }
        
        private void EsvaixStoryboard_CurrentTimeInvalidated(object sender, EventArgs e)
        {

        }

        private void sldVelocitat_ValueChanged(object sender, RoutedEventArgs e)
        {
            
        }
        
    }
}

