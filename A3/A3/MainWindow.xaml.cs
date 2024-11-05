using A3.DAO;
using System.IO;
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

namespace A3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private DAOFactory factory = null;
        private IDAO dao = null;
        public MainWindow()
        {
            factory = new DAOFactory();
            InitializeComponent();
            lstBins.ItemsSource = Directory.GetFiles("./").Where(a => a.EndsWith(".bin"));

        }

        //Set Seed
        private void btnSeed_Click(object sender, RoutedEventArgs e)
        {
            if(txtWriteSeed.Text.Trim().Length > 0 && txtWriteSeed.Text.Trim().Length<5)
            {
                if (dao == null)
                {
                    dao = factory.CreateMSQA(txtWriteSeed.Text);
                    lblMaxLength.Text = dao.MaxLengthOfName.ToString();

                }
                else
                {
                    dao.Dispose();
                    dao = null;
                    dao = factory.CreateMSQA(txtWriteSeed.Text);
                    lblMaxLength.Text = dao.MaxLengthOfName.ToString();

                }
            }
            lstBins.ItemsSource = Directory.GetFiles("./").Where(a => a.EndsWith(".bin"));

        }

        //Test
        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            if (dao != null)
            {
                if (dao.IsFeasable(txtWriteNom.Text.Trim(), txtWriteNIF.Text.Trim()))
                {
                    MessageBox.Show("Es pot");
                }
                else
                {
                    MessageBox.Show("No es pot escriure");
                }

            }
            else
            {
                MessageBox.Show("Carrega una seed primer");
            }
                
            
        }
        //Write file
        private void btnWrite_Click(object sender, RoutedEventArgs e)
        {
            if (dao.IsFeasable(txtWriteNom.Text.Trim(), txtWriteNIF.Text.Trim()))
            {
                dao.WriteData(txtWriteNom.Text.Trim(), txtWriteNIF.Text.Trim());
                txtReadSeed.Text = "";
                txtReadNIF.Text = "";
                txtReadNom.Text = "";
                MessageBox.Show($"Arxiu {txtWriteSeed.Text}.bin guardat correctament");
            }
            else
            {
                MessageBox.Show($"No s'ha pogut crear. Nom massa llarg.");
            }
        }

        //Read file
        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            if (lstBins.SelectedItem == null) MessageBox.Show("Sel·lecciona un element valid");
            else
            {
                string seed = lstBins.SelectedItem.ToString();
                seed = seed.Substring(2, seed.Length - 6);
                if (seed.Length == 4)
                {
                    if (dao == null)
                    {
                        dao = factory.CreateMSQA(seed);
                    }
                    else
                    {
                        dao.Dispose();
                        dao = null;
                        dao = factory.CreateMSQA(seed);

                    }
                    if (dao.Empty)
                    {
                        MessageBox.Show("Fitxer es buit");
                        txtReadSeed.Text = "";
                        txtReadNIF.Text = "";
                        txtReadNom.Text = "";
                    }
                    else
                    {
                        txtReadSeed.Text = seed;
                        txtReadNIF.Text = dao.Nif;
                        txtReadNom.Text = dao.Name;
                    }
                }
                else
                    MessageBox.Show("Sel·lecciona un element valid");
            }
        }
    }
}