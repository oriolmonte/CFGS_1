using ClasePoker.Model;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClasePoker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Baralla baralla = new Baralla();
        Ma ma = new Ma();
        private void PintaMa(Panel panell)
        {
            panell.Children.Clear();
            foreach(Carta carta in ma)
            {
                Image imgNovaCarta = new Image();
                imgNovaCarta.Source = (ImageSource)FindResource(carta.ClauImatge);
                panell.Children.Add(imgNovaCarta);

            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnReverteix_Click(object sender, RoutedEventArgs e)
        {
            
            
            Carta cartaActual = baralla.Roba();
            Image imgCarta = new Image();
            imgCarta.Source = (ImageSource)FindResource(cartaActual.ClauImatge);
            stkBaralla.Children.Add(imgCarta);
            imgCarta.MouseDown += TriaCarta;
            imgCarta.Tag = cartaActual;
           
            
        }

        private void TriaCarta(object sender, MouseButtonEventArgs e)
        {
            Image imgCarta = (Image)sender;
            Carta cartaActual = (Carta)imgCarta.Tag;
            //Image imgNovaCarta = new Image();
            //imgNovaCarta.Source = (ImageSource)FindResource(cartaActual.ClauImatge);
            //stkMa.Children.Add(imgNovaCarta);
            ma.Afegeix(cartaActual);
            PintaMa(stkMa);
        }
        private void btnTria_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}