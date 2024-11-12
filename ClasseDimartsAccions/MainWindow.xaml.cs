using Microsoft.Win32;
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

namespace ClasseDimartsAccions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String? NomDocument {  get; set; }
        bool IsDesat {  get; set; }
        double MidaFont { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            MidaFont = 12;
            IsDesat = true;
            NomDocument = null;
            txtDocument.FontSize = MidaFont;
            sbiZoom.Content = MidaFont;
            CreaBindings();
        }

        private void CreaBindings()
        {
            CommandBinding copiaBinding = new CommandBinding(ApplicationCommands.Copy);
            copiaBinding.Executed += CopiaBinding_Executed;
            //NO T'OBLIDIS
            this.CommandBindings.Add(copiaBinding);

            CommandBinding tallaBinding = new CommandBinding(ApplicationCommands.Cut);
            tallaBinding.Executed += TallaBinding_Executed;
            //NO T'OBLIDIS
            this.CommandBindings.Add(tallaBinding);

            CommandBinding enganxaBinding = new CommandBinding(ApplicationCommands.Paste);
            enganxaBinding.Executed += enganxaBinding_Executed;
            //NO T'OBLIDIS
            this.CommandBindings.Add(enganxaBinding);

            CommandBinding desferBinding = new CommandBinding(ApplicationCommands.Undo);
            desferBinding.Executed += desferBinding_Executed;
            desferBinding.CanExecute += desferBinding_CanExecute;
            //NO T'OBLIDIS
            this.CommandBindings.Add(desferBinding);
            CommandBinding refesBinding = new CommandBinding(ApplicationCommands.Redo);
            refesBinding.Executed += refesBinding_Executed;
            desferBinding.CanExecute += refesBinding_CanExecute;
            //NO T'OBLIDIS
            this.CommandBindings.Add(refesBinding);
            CommandBinding augmentaMida = new CommandBinding(CommandsEditor.AugmentaMida);
            augmentaMida.Executed += augmentaMida_Executed;
            //NO T'OBLIDIS
            this.CommandBindings.Add(augmentaMida);
            CommandBinding disminueixMida = new CommandBinding(CommandsEditor.DisminueixMida);
            disminueixMida.Executed += dismiueixMida_Executed;
            //NO T'OBLIDIS
            this.CommandBindings.Add(disminueixMida);
            
        }

        private void dismiueixMida_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int valor = int.Parse((string)e.Parameter);
            txtDocument.FontSize-=valor;
        }

        private void augmentaMida_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int valor = int.Parse((string)e.Parameter);
            txtDocument.FontSize+=valor;
        }

        private void refesBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = txtDocument.CanRedo;
        }

        private void desferBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = txtDocument.CanUndo;
        }

        private void refesBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtDocument.Redo();
        }

        private void desferBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtDocument.Undo();
        }

        private void enganxaBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtDocument.Paste();    
        }

        private void TallaBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtDocument.Cut();
        }

        private void CopiaBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtDocument.Copy();
        }

        private void mnuAmaga_Click(object sender, RoutedEventArgs e)
        {
            if (mnuAmaga.IsChecked)
            {
                tbpEines.Visibility = Visibility.Collapsed;
                mnuAmaga.IsChecked = false;
            }
            else
            {
                tbpEines.Visibility = Visibility.Visible;
                mnuAmaga.IsChecked = true;
            }
        }

        private void CommandNew_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtDocument.Text = "";
            NomDocument = null;

        }

        private void CommandOpen_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //obre un fitxer
        }

        private void CommandDesa_Executed(object sender, ExecutedRoutedEventArgs e)
        private void CommandDesa_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DesaFitxer(NomDocument);
            IsDesat = true;
        }

        private void CommandDesa_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !IsDesat;
        }

        private void CommandTanca_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void CommandDesaCom_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DesaFitxer(null);
            IsDesat = true;
        }

        private void txtDocument_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsDesat = false;
        }

        private void txtDocument_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int linia = txtDocument.GetLineIndexFromCharacterIndex(txtDocument.SelectionStart);
            int columna = txtDocument.SelectionStart-txtDocument.GetCharacterIndexFromLineIndex(linia);
            sbiPosicio.Content = $"Ln {linia}, Col {columna}";
        }
        public void ObreFitxer()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arxiu de text(*.txt; *csv) | *.txt;*.csv | Tots els arxius (*.*)|*.*"; 
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if(openFileDialog.ShowDialog()==true)
            {
                txtDocument.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ObreFitxer();
        }
        public void DesaFitxerAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Arxiu de text(*.txt; *csv) | *.txt;*.csv | Tots els arxius (*.*)|*.*";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, txtDocument.Text);
                NomDocument = saveFileDialog.FileName;
                Title = saveFileDialog.FileName;
                IsDesat = true;
            }
        }
        public void DesaFitxer(String? nom)
        {
            if(nom==null)
            {
                DesaFitxerAs();
            }
            else
            {
                File.WriteAllText(nom, txtDocument.Text);
                IsDesat = true;
            }
        }
    }
}