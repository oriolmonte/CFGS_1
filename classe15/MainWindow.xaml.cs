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

namespace classe15
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<diesSetmana> diesSetmanaList = new List<diesSetmana>();
        List<string> diesSetmanaListString = new List<string>();

        enum diesSetmana { Dilluns,Dimarts,Dimecres,Dijous,Divendres,Dissabte,Diumenge };

        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void btnMissatge_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resposta = MessageBox.Show(
                "Aquest és el missatge que surt al messagebox",
                "Titol messagebox",
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Information,
                MessageBoxResult.No ,
                MessageBoxOptions.DefaultDesktopOnly | MessageBoxOptions.RightAlign
                );
            Title = resposta.ToString();

        }

        private void btnEnum_Click(object sender, RoutedEventArgs e)
        {
            
            Array diesArray = Enum.GetValues(typeof(diesSetmana));
            String[] diesSetString = Enum.GetNames(typeof(diesSetmana));
            foreach(diesSetmana d in diesArray) 
            {
                diesSetmanaList.Add(d);
            }
            diesSetmanaListString.AddRange(diesSetString);
            lstDies.ItemsSource = diesSetmanaList;
            cmbDies.ItemsSource = diesSetString;
        }

        private void btnAfegeixCombo_Click(object sender, RoutedEventArgs e)
        {
            //diesSetmana dia = Enum.Parse<diesSetmana>(cmbDies.Text);
            //Enum.TryParse(cmbDies.Text, out dia);
            if(cmbDies.Text!="" && !lstAfegeix.Items.Contains(cmbDies.Text))
                lstAfegeix.Items.Add(cmbDies.Text);
        }

        private void btnAfegeixComboLlista_Click(object sender, RoutedEventArgs e)
        {
            //lstAfegeix.Items.Add(lstPata.SelectedItem.ToString());
            if(lstPata.SelectedIndex!=-1)
                lstAfegeix.Items.Add(((ListBoxItem)(lstPata.SelectedItem)).Content);
        }

        private void btnAfegeixMolts(object sender, RoutedEventArgs e)
        {
        }

        private void btnAfegeixMoltss_Click(object sender, RoutedEventArgs e)
        {
            if (lstPata.SelectedItems.Count > 0)
                foreach(var d in lstPata.SelectedItems)
                {
                    lstAfegeix.Items.Add(((ListBoxItem)(d)).Content);
                }

        }

        private void btnDeselecciona_Click(object sender, RoutedEventArgs e)
        {
            lstPata.SelectedItems.Clear();
        }

        private void btnAfegeixBotons_Click(object sender, RoutedEventArgs e)
        {
            foreach (var d in lstDies.SelectedItems)
            {
                Button newButton = new Button();
                newButton.Content = d;
                newButton.Click += NewButton_Click;
                stkContenidor.Children.Add(newButton);
            }
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            Title = ((Button)sender).Content.ToString();
            Window1 f = new Window1();
            f.ShowDialog();
            Title = f.count.ToString();
        }
    }
}