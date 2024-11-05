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

        #region Mouse
        Point anterior, actual;
        SolidColorBrush pinzellNegre = Brushes.Black;
        SolidColorBrush pinzellRosa = Brushes.DeepPink;
        SolidColorBrush pinzellClar = Brushes.LightCoral;
        #endregion


        public MainWindow()
        {
            InitializeComponent();
            #region Cronometre
            cronometre.Interval = new TimeSpan(100);
            cronometre.Tick += Cronometre_Tick;
        }

        private void Cronometre_Tick(object? sender, EventArgs e)
        {
            DateTime ara = DateTime.Now;
            TimeSpan diferencia = ara.Subtract(inici);

            // podriem sumar un a cada tick pero si ens perdem ticks... llavors 
            tbkCronometre.Text =
                String.Format($"{diferencia.Hours:00}:{diferencia.Minutes:00}:{diferencia.Seconds:00}.{diferencia.Milliseconds:00}");
        }
        #endregion
        Random rnd = new Random();
        int numBotons = 0;


        #region liada
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
            if (!aturat)
            {
                cronometre.Stop();
                inici = DateTime.Now;
            }
            aZero = false;
        }
        #endregion
        #region ESDEVENIMENTS ENRUTATS
        private void TabItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Title += "->Tabitem";
        }

        private void tbkGroc_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Title = "->Groc";

            e.Handled = true; //TALLA LA PROPAGACIO!
        }

        private void tbkVerd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Title = "->Verd";
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Title += "->Finestra";
        }

        private void btnFocus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Title += "->Focis";
        }

        private void grdFinestra_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Title += "->Graella";
        }
        #endregion
        #region TECLAT
        private void txtText_TextChanged(object sender, TextChangedEventArgs e)
        {
            Resultat2.Text = $" Mida{txtText.Text.Length}";
            
        }

        private void txtText_KeyDown(object sender, KeyEventArgs e)
        {
            Resultat1.Text = e.Key.ToString();
            Resultat2.Text = $" Bloq:{Keyboard.Modifiers.ToString()}";
            
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.B)
            {
                e.Handled=true;//NO PROPAGARA LA B   
            }
        }
        #endregion
        #region Mouse

        private void cnvPissarra_MouseEnter(object sender, MouseEventArgs e)
        {
            actual = e.GetPosition(cnvPissarra); //GetPosition RELATIU A PARAMETRE
            tbX.Text = $"X:{Math.Round(actual.X)}";
            tbY.Text = $"Y:{Math.Round(actual.Y)}";
        }

        private void cnvPissarra_MouseMove(object sender, MouseEventArgs e)
        {
            anterior = actual;
            actual = e.GetPosition(cnvPissarra); //GetPosition RELATIU A PARAMETRE
            tbX.Text = $"X:{Math.Round(actual.X)}";
            tbY.Text = $"Y:{Math.Round(actual.Y)}";

            if(e.LeftButton == MouseButtonState.Pressed)
            {
                Line linia = new Line();
                linia.Stroke = pinzellNegre;
                linia.StrokeThickness = 2;
                linia.X1 = anterior.X;
                linia.Y1 = anterior.Y;
                linia.X2 = actual.X;
                linia.Y2 = actual.Y;
                cnvPissarra.Children.Add(linia);
                //BITWISE AND MINVENTO
                //000010
                //000001 &
                //-------
                //000011

                if ((ModifierKeys.Alt & Keyboard.Modifiers) == ModifierKeys.Alt) 
                {
                    Ellipse elipse = new Ellipse();
                    elipse.Width = 25;
                    elipse.Height = 25;
                    elipse.Stroke = pinzellClar;
                    elipse.StrokeThickness = 2;
                    elipse.SetValue(Canvas.LeftProperty, actual.X - 12.5);
                    Canvas.SetTop(elipse, actual.Y - 12.5);
                    cnvPissarra.Children.Add(elipse);
                }
            }
            if (e.RightButton == MouseButtonState.Pressed)
            {
                Line linia = new Line();
                linia.Stroke = pinzellRosa;
                linia.StrokeThickness = 2;
                linia.X1 = anterior.X;
                linia.Y1 = anterior.Y;
                linia.X2 = actual.X;
                linia.Y2 = actual.Y;
                cnvPissarra.Children.Add(linia);
            }

        }

        private void cnvPissarra_MouseLeave(object sender, MouseEventArgs e)
        {
            tbX.Text = $"X:FORA";
            tbY.Text = $"Y:FORA";
        }

        #endregion


    }


}


