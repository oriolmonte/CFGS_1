using System.Globalization;
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

namespace Restaurant
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

        private void butPuro_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void butCopa_Checked(object sender, RoutedEventArgs e)
        {
            if (butPuro.IsEnabled == false)
            {
                butPuro.IsEnabled = true;
            }
 
        }

        private void butClear_Click(object sender, RoutedEventArgs e)
        {
            foreach(RadioButton rb in lstPrimerPlat.Children)
            {
                rb.IsChecked = false;   
            }
            foreach (RadioButton rb in lstSegonPlat.Children)
            {
                rb.IsChecked = false;
            }
            foreach (RadioButton rb in lstPostre.Children)
            {
                rb.IsChecked = false;
            }
            foreach (CheckBox rb in lstExtra.Children)
            {
                rb.IsChecked = false;
            }
        }
        private void butSave_Click(object sender, RoutedEventArgs e)
        {
            List<Item> factura = Factura();
            Factura winFactura = new Factura(factura);
            winFactura.Show();
        }



        public List<Item> Factura ()
        {
            List<Item> factura = new List<Item>();
            foreach (RadioButton r in lstPrimerPlat.Children) {

                if (r.IsChecked == true)
                {
                    double d = Convert.ToDouble(r.Tag, new CultureInfo("en-US"));
                    var current = new Item(r.Content.ToString(), d);
                    factura.Add(current);
                }
            }
            foreach (RadioButton r in lstSegonPlat.Children)
            {

                if (r.IsChecked == true)
                {
                    double d = Convert.ToDouble(r.Tag, new CultureInfo("en-US"));
                    var current = new Item(r.Content.ToString(), d);
                    factura.Add(current);
                }
            }
            foreach (RadioButton r in lstPostre.Children)
            {

                if (r.IsChecked == true)
                {
                    double d = Convert.ToDouble(r.Tag, new CultureInfo("en-US"));
                    var current = new Item(r.Content.ToString(), d);
                    factura.Add(current);
                }
            }
            foreach (CheckBox r in lstExtra.Children)
            {

                if (r.IsChecked == true)
                {
                    double d = Convert.ToDouble(r.Tag, new CultureInfo("en-US"));
                    var current = new Item(r.Content.ToString(), d);
                    factura.Add(current);
                }
            }
            return factura;
        }
    }

}
