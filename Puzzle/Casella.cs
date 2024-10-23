using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Puzzle
{
    class Casella : ContentControl
    {
        #region Propietats i Atributs
        private string text;
        private int fila;
        private int columna;
        private int valorDesitjat;
        private System.Windows.Media.Color colorFonsCorrecte;
        private System.Windows.Media.Color colorFonsErroni;
        private System.Windows.Media.Color colorLletraIncorrecte;
        private System.Windows.Media.Color colorLletraCorrecte;

        
        public string Text { get => text; set => text = value; }
        public int Fila { get => fila; set => fila = value; }
        public int Columna { get => columna; set => columna = value; }
        public int ValorActual { get => int.Parse(text);}
        public int ValorDesitjat { get => valorDesitjat; set => valorDesitjat = value; }
        public System.Windows.Media.Color ColorFonsCorrecte { get => colorFonsCorrecte; set => colorFonsCorrecte = value; }
        public System.Windows.Media.Color ColorFonsErroni { get => colorFonsErroni; set => colorFonsErroni = value; }
        public System.Windows.Media.Color ColorLletraIncorrecte { get => colorLletraIncorrecte; set => colorLletraIncorrecte = value; }
        public System.Windows.Media.Color ColorLletraCorrecte { get => colorLletraCorrecte; set => colorLletraCorrecte = value; }
        public bool EstaBenColocada {
            get
            {
                return ValorActual == ValorDesitjat;
            }
             
        }
        public bool EsVisible { get => Text=="";}
        #endregion

        SolidColorBrush pinzellFonsCorrecte = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255,186,255,197));
        SolidColorBrush pinzellFonsIncorrecte = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 191,186));
        SolidColorBrush pinzellLletraCorrecte = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 19, 71, 0));
        SolidColorBrush pinzellLletraIncorrecte = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 71, 0, 0));

        public Casella(int valorDesitjat)

        {
            ValorDesitjat = valorDesitjat;
            Border marc = new Border();
            Viewbox viewbox = new Viewbox();
            TextBlock textBlock = new TextBlock();
            this.Content = marc;
            marc.Child = viewbox;
            viewbox.Child = textBlock;

            #region Colors Inicials
            marc.BorderBrush = new SolidColorBrush(Colors.Black);
            marc.BorderThickness = new Thickness(3, 3, 3, 3);
            if (EstaBenColocada)
            {
                marc.BorderBrush = pinzellFonsCorrecte;
                textBlock.Foreground = pinzellLletraCorrecte;
            }
            else
            {
                marc.BorderBrush = pinzellFonsIncorrecte;
                textBlock.Foreground = pinzellLletraIncorrecte;
            }
            #endregion
        }



    }
}
