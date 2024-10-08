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

namespace ControlsNumericsBindings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    
    public partial class MainWindow : Window
    {
        Color color = Color.FromRgb(0,255,0);
        SolidColorBrush pinzell = new SolidColorBrush();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnExecuta_Click(object sender, RoutedEventArgs e)
        {
            var colors = new SolidColorBrush(Colors.CornflowerBlue);
            var reinols = Brushes.LemonChiffon;
            pinzell.Color = color;
            stkPanell.Background = pinzell;
            this.Background = reinols;
        }

        private void btnExecutaColor_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            color = Color.FromRgb((byte)r.Next(256), (byte)r.Next(256), (byte)r.Next(256));
            pinzell.Color = color;
            this.Background = Brushes.Coral;
        }

        private void sbValor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbScrollBar.Text = sbValor.Value.ToString();
        }

        private void sldValor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbSlider.Text = sldValor.Value.ToString();
        }
    }
}