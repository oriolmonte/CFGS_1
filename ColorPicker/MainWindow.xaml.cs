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
            Pinta();
            colorPicker.SelectedColor= Color.FromArgb((byte)scbA.Value, (byte)scbR.Value, (byte)scbG.Value, (byte)scbB.Value);
        }

        private void scbR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
                Pinta();
        }

        private void scbA_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Pinta();
        }
        private void Pinta()
        {
            if (scbR is not null)
            {
                color = Color.FromArgb((byte)scbA.Value, (byte)scbR.Value, (byte)scbG.Value, (byte)scbB.Value);
                brush.Color = color;
                rectangle.Fill = brush;
                colorPicker.SelectedColor=color;
            }

        }

        private void scbG_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Pinta();
        }

        private void scbB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Pinta();
        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            color = colorPicker.SelectedColor.Value;
            scbA.Value = colorPicker.SelectedColor.Value.A;
            scbR.Value = colorPicker.SelectedColor.Value.R;
            scbG.Value = colorPicker.SelectedColor.Value.G;
            scbB.Value = colorPicker.SelectedColor.Value.B;

            Pinta();
        }

    }
}