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

namespace PrimerAppWPF
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

        private void btnWrapPanel_Click(object sender, RoutedEventArgs e)
        {
           wndWrapPanel finestra = new wndWrapPanel();
           finestra.Show();
        }

        private void btnDockPanel_Click(object sender, RoutedEventArgs e)
        {
            wndDockPanel finestra = new wndDockPanel();
            finestra.Show();
        }

        private void btnStackPanel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCanvas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}