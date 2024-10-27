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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Puzzle
{
    /// <summary>
    /// Lógica de interacción para TaulerJoc.xaml
    /// </summary>
    public partial class TaulerJoc: Window
    {
        int files = 0;
        int columnes = 0;
        public TaulerJoc(int files, int columnes)
        {
            this.files = files;
            this.columnes = columnes;
            cronometre.Interval = new TimeSpan(100);
            cronometre.Tick += Cronometre_Tick;

            InitializeComponent();

        }

        private void Cronometre_Tick(object? sender, EventArgs e)
        {
            DateTime ara = DateTime.Now;
            TimeSpan diferencia = ara.Subtract(inici);

            // podriem sumar un a cada tick pero si ens perdem ticks... llavors 
            sbiCrono.Content =
                String.Format($"{diferencia.Hours:00}:{diferencia.Minutes:00}:{diferencia.Seconds:00}.{diferencia.Milliseconds:00}");
            var tauler = this.dckMain.Children.OfType<Tauler>().First();
            if (tauler != null && tauler.EstaSolucionat)
            {
                tauler.Time = sbiCrono.Content.ToString();
                cronometre.Stop();
            }


        }
        DispatcherTimer cronometre = new DispatcherTimer();
        DateTime inici = DateTime.Now;

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Button current = (Button)sender;
            current.Visibility=Visibility.Collapsed;
            var tauler = new Tauler(files, columnes);
            this.dckMain.Children.Add(tauler);
            inici = DateTime.Now;
            cronometre.Start();
            sbiMoves.Content = "Nombre de movimients: " + tauler.Moves.ToString();
            sbiProgress.Content = tauler.BenColocades;

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var tauler = this.dckMain.Children.OfType<Tauler>().First();
            sbiMoves.Content = "Nombre de movimients: "+tauler.Moves.ToString();
            sbiProgress.Content = tauler.BenColocades;

        }

    }
}
