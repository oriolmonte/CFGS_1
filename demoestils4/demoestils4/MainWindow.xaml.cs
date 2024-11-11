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

namespace demoestils4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }
        public class Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        private void LoadData()
        {
            // Create a sample list of items
            List<Item> items = new List<Item>
            {
                new Item { Id = 1, Name = "Item 1", Description = "Description of Item 1" },
                new Item { Id = 2, Name = "Item 2", Description = "Description of Item 2" },
                new Item { Id = 3, Name = "Item 3", Description = "Description of Item 3" },
                new Item { Id = 4, Name = "Item 4", Description = "Description of Item 4" },
                new Item { Id = 5, Name = "Item 5", Description = "Description of Item 5" },
            };

            // Bind the items list to DataGrid and ListView
            DataGridName.ItemsSource = items;
            ListViewName.ItemsSource = items;
            List<string> itemss = new List<string>();
            foreach (Item item in items)
            {
                itemss.Add(item.Description);
            }
            lst.ItemsSource = itemss;
        }
    }
}