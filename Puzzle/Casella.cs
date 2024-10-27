using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;

namespace Puzzle
{
    class Casella : ContentControl
    {
        #region Propietats i Atributs
        private int fila;
        private int columna;
        private int valorDesitjat;
        private int valorActual;
        private System.Windows.Media.Color colorFonsCorrecte;
        private System.Windows.Media.Color colorFonsErroni;
        private System.Windows.Media.Color colorLletraIncorrecte;
        private System.Windows.Media.Color colorLletraCorrecte;

        
        public string Text { get
            {
                Border marc = (Border)(Content);
                Viewbox vbox = (Viewbox)marc.Child;
                TextBlock text = (TextBlock)vbox.Child;
                return text.Text;

            }
            set
            {
                Border marc = (Border)(Content);
                Viewbox vbox = (Viewbox)marc.Child;
                TextBlock text = (TextBlock)vbox.Child;
                text.Text = value;
            }
        }
        public int Fila { get => fila; set => fila = value; }
        public int Columna { get => columna; set => columna = value; }
        public int ValorActual { get => valorActual; set => valorActual = value; }
        public int ValorDesitjat { get => valorDesitjat; set => valorDesitjat = value; }
        public System.Windows.Media.Color ColorFonsCorrecte { get => colorFonsCorrecte; set => colorFonsCorrecte = value; }
        public System.Windows.Media.Color ColorFonsErroni { get => colorFonsErroni; set => colorFonsErroni = value; }
        public System.Windows.Media.Color ColorLletraIncorrecte { get => colorLletraIncorrecte; set => colorLletraIncorrecte = value; }
        public System.Windows.Media.Color ColorLletraCorrecte { get => colorLletraCorrecte; set => colorLletraCorrecte = value; }
        public bool EstaBenColocada {
            get
            {
                if (valorActual == valorDesitjat)
                {
                    Border marc = (Border)(Content);
                    Viewbox vbox = (Viewbox)marc.Child;
                    TextBlock text = (TextBlock)vbox.Child;

                    marc.Background = pinzellFonsCorrecte;
                    text.Foreground = pinzellLletraCorrecte;
                }
                else  
                {
                    Border marc = (Border)(Content);
                    Viewbox vbox = (Viewbox)marc.Child;
                    TextBlock text = (TextBlock)vbox.Child;
                    marc.Background = pinzellFonsIncorrecte;
                    text.Foreground = pinzellLletraIncorrecte;
                }
                return valorActual==valorDesitjat;
            }
            set
            {
                if (valorActual == valorDesitjat)
                {
                    Border marc = (Border)(Content);
                    Viewbox vbox = (Viewbox)marc.Child;
                    TextBlock text = (TextBlock)vbox.Child;

                    marc.Background = pinzellFonsCorrecte;
                    text.Foreground = pinzellLletraCorrecte;
                }
                else if(EsVisible)
                {
                    Border marc = (Border)(Content);
                    Viewbox vbox = (Viewbox)marc.Child;
                    TextBlock text = (TextBlock)vbox.Child;
                    marc.Background = pinzellFonsIncorrecte;
                    text.Foreground = pinzellLletraIncorrecte;
                }
                else
                {
                    this.Text = "";
                    Border marc = (Border)(Content);
                    Viewbox vbox = (Viewbox)marc.Child;
                    TextBlock text = (TextBlock)vbox.Child;
                    marc.Background = default;
                    text.Foreground = default;

                }
            }

        }
        public bool EsVisible
        {
            get => this.IsVisible;
            set
            {
                if (value==false)
                {
                    this.Text = "";
                    Border marc = (Border)(Content);
                    Viewbox vbox = (Viewbox)marc.Child;
                    TextBlock text = (TextBlock)vbox.Child;
                    marc.Background = default;
                    text.Foreground = default;
                }

            }
        }
        #endregion

        public static SolidColorBrush pinzellFonsCorrecte = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255,186,255,197));
        public static SolidColorBrush pinzellFonsIncorrecte = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 191,186));
        public static SolidColorBrush pinzellLletraCorrecte = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 19, 71, 0));
        public static SolidColorBrush pinzellLletraIncorrecte = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 71, 0, 0));

        public Casella()

        {
            Border marc = new Border();
            Viewbox viewbox = new Viewbox();
            TextBlock textBlock = new TextBlock();
            this.Content = marc;
            marc.Child = viewbox;
            viewbox.Child = textBlock;
            #region Colors Inicials
            marc.BorderBrush = new SolidColorBrush(Colors.Black);
            marc.BorderThickness = new Thickness(3, 3, 3, 3);
            #endregion
        }

        // override object.Equals
        public bool Iguals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Casella other = obj as Casella;
            if (this.Fila == other.Fila && this.Columna == other.Columna)
            {
                return true;
            }
            else return false;
        }


    }
}
