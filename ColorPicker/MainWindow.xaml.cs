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

namespace ColorPicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Color color = new Color();
        SolidColorBrush brush = new SolidColorBrush();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            color = Color.FromArgb((byte)scbA.Value, (byte)scbR.Value, (byte)scbG.Value, (byte)scbB.Value);
            brush.Color = color;
            rectangle.Fill = brush;
        }
    }
}