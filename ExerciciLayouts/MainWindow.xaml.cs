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

namespace ExerciciLayouts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calculadora_Click(object sender, RoutedEventArgs e)
        {
            Calculadora finestra = new Calculadora();
            finestra.Show();
        }

        private void Dibuix_Click(object sender, RoutedEventArgs e)
        {
            Dibuix finestra = new Dibuix();
            finestra.Show();
        }

        private void Formulari_Click(object sender, RoutedEventArgs e)
        {
            Formulari finestra = new Formulari();
            finestra.Show();

        }

        private void TriaColors_Click(object sender, RoutedEventArgs e)
        {
            TriaColors finestra = new TriaColors();
            finestra.Show();

        }

        private void Textos_Click(object sender, RoutedEventArgs e)
        {
            Text finestra = new Text();
            finestra.Show();

        }

        private void NavBar_Click(object sender, RoutedEventArgs e)
        {
            TextMenu finestra = new TextMenu();
            finestra.Show();
        }
    }
}