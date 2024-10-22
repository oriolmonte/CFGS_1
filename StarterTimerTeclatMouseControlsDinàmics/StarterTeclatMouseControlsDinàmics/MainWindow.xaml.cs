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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace StarterTeclatMouseControlsDinàmics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        public MainWindow()
        {
            InitializeComponent();
            #region Cronometre
            cronometre.Interval = new TimeSpan(100);
            cronometre.Tick += Cronometre_Tick;
            #endregion
        }

        private void Cronometre_Tick(object? sender, EventArgs e)
        {
            DateTime ara = DateTime.Now;
            TimeSpan diferencia = ara.Subtract(inici);

            // podriem sumar un a cada tick pero si ens perdem ticks... llavors 
            tbkCronometre.Text =
                String.Format($"{diferencia.Hours:00}:{diferencia.Minutes:00}:{diferencia.Seconds:00}.{diferencia.Milliseconds:00}");
        }
        #region Controls Dinàmics
        Random rnd = new Random();
        int numBotons = 0;

        private void sldNumFiles_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.graGraella.NFiles = (int)e.NewValue;
        }

        private void btnCrea_Click(object sender, RoutedEventArgs e)
        {
            List<Dock> docks = Enum.GetValues<Dock>().ToList();
            Element element = new Element();
            element.ColorFons = SortejaColor();
            element.ColorMarc = SortejaColor();
            element.ColorText = SortejaColor();
            //Propietat de dependencia si no ho passo a un grid no passa res... si ho poso a un grid sortiria al 2 NO HA DE SABER QUE HI ES...
            element.SetValue(Grid.RowProperty, 2);
            Dock dock = docks[rnd.Next(docks.Count)];
            //Aqui si que entra 
            element.SetValue(DockPanel.DockProperty, Dock.Left);
            DockPanel.SetDock(element, dock);
            element.Text = dock.ToString();
            dckBotons.Children.Add(element);
            numBotons++;
            sbiNumBotons.Content = $"Num Botons: {numBotons}";
            element.MouseDown += Element_MouseDown;

        }
       

        private void Element_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Element elementActual = (Element)sender;
            elementActual.ColorMarc = SortejaColor();
        }

        private Color SortejaColor()
        {
            return Color.FromRgb(
                (Byte)rnd.Next(256),
                (Byte)rnd.Next(256),
                (Byte)rnd.Next(256)
                );
        }

        private void btnElimina_Click(object sender, RoutedEventArgs e)
        {
            dckBotons.Children.Clear();
            numBotons = 0;
            sbiNumBotons.Content = $"Num Botons: {numBotons}";

        }
        #endregion
        
        DispatcherTimer cronometre = new DispatcherTimer();
        DateTime inici = DateTime.Now;
        bool aZero = false;
        bool aturat = true;

        private void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            if (!aZero)
            {
                inici = DateTime.Now;
                aZero = true;
                aturat = false;
                cronometre.Start();
            }
            else
            {
                if (aturat)
                {
                    aturat = false;
                    cronometre.Start();
                }
                else
                {
                    aturat = true;
                    cronometre.Stop();
                }
            }
        }

        private void btnZero_Click(object sender, RoutedEventArgs e)
        {
            tbkCronometre.Text = "00:00:00";
            if(!aturat)
            {
                cronometre.Stop();
                inici = DateTime.Now;
            }
            aZero = false;
        }
    }
}
