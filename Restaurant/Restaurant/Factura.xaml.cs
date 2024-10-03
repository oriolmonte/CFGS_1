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

namespace Restaurant
{
    /// <summary>
    /// Lógica de interacción para Factura.xaml
    /// </summary>
    public partial class Factura : Window
    {
        private List<Item> items;
        public List<Item> Items { get => items; set => items = value; }

        public Factura(List<Item> items)
        {
            this.Items = items;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<TextBlock> linies = new List<TextBlock>(); 
            foreach(TextBlock r in grdFactura.Children)
            {
                linies.Add(r);
            }
            double total = 0;
            for(int i = 0; i < items.Count; i++)
            {
                linies.Where(a => a.Name == $"n{i}").First().Text = items[i].Name;
                linies.Where(a => a.Name == $"p{i}").First().Text = items[i].Preu.ToString();
                total += items[i].Preu;
            }
            this.total.Text = total.ToString();
        }

    }
}
