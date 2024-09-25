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
    }
}