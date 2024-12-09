using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Ordenacions.Viewmodel
{   
    

    public partial class PintaArrayViewModel : ObservableObject
    {
        static ObservableCollection<string> figures = ["Barres", "Punts"];
        static ObservableCollection<string> ordenacions = ["Bubble Sort", "Cocktail Sort", "Gnome Sort"];
        [ObservableProperty]
        ObservableCollection<string> opcionsFigures = figures;
        [ObservableProperty]
        ObservableCollection<string> opcionsOrdenacions = ordenacions;
        [ObservableProperty]
        Color colorFons = Colors.White;
        [ObservableProperty]
        Color colorCorrecte = Colors.Green;
        [ObservableProperty]
        Color colorIncorrecte = Colors.Red;
        [ObservableProperty]
        Color colorIntercanvi = Colors.Yellow;
        [ObservableProperty]
        int length;
        [ObservableProperty]
        List<int> numeros;
        [ObservableProperty]
        ObservableCollection<Rectangle> rectangles;
        [ObservableProperty]
        int gruix;
        [ObservableProperty]
        int cornerRadius;
        [ObservableProperty]
        int tempsEspera;
        [ObservableProperty]
        bool aleatori = true;
        double xOffset = 0;
        private bool isUpdating;
        partial void OnAleatoriChanging(bool value)
        {
            if (isUpdating) return;

            isUpdating = true;
            try
            {
                if (value)
                    Invertit = false;
                else if (!value && !Invertit)
                    Aleatori = true;
            }
            
            finally
            {
                isUpdating = false;
            }
        }
        [ObservableProperty]
        bool invertit = false;
        partial void OnInvertitChanging(bool value)
        {
            if (isUpdating) return;

            isUpdating = true;

            try
            {
                if (value)
                    Aleatori = false;
                else if (!value && !Aleatori)
                    Invertit = true;
            }
            finally
            {
                isUpdating = false;
            }
        }
        
        [ObservableProperty]
        bool marcaIntercanvis;
        [ObservableProperty]
        SolidColorBrush fons = new SolidColorBrush(Colors.White);
        [ObservableProperty]
        SolidColorBrush correcte = new SolidColorBrush(Colors.Green);
        [ObservableProperty]
        SolidColorBrush incorrecte = new SolidColorBrush(Colors.Red);
        [ObservableProperty]
        SolidColorBrush intercanvi = new SolidColorBrush(Colors.Yellow);
        [ObservableProperty]
        private string selectedFigura;
        [ObservableProperty]
        private string selectedOrdenacions;

        public PintaArrayViewModel()
        {
            length = 5;
            numeros = new List<int>();
            rectangles = new ObservableCollection<Rectangle>();
            gruix = 2;
            cornerRadius = 5;
            tempsEspera = 100;
            selectedFigura = opcionsFigures[0];
            selectedOrdenacions = opcionsOrdenacions[0];
        }
        // HA DE TENIR EL CANVAS COM A PARAMETRE
        [RelayCommand]
        private void Crea()
        {           
            if (Invertit)
            {
                for(int i = Length; i<=1; i++)
                {
                    Numeros.Add(i);
                }
            }
            else
            {
                for(int i = 1; i<=Length; i++) 
                {
                    Numeros.Add(i);
                }
            }
            if (Aleatori)
            {
                Random random = new Random();
                for (int i = Numeros.Count - 1; i > 0; i--)
                {
                    int j = random.Next(0, i + 1);
                    (Numeros[i], Numeros[j]) = (Numeros[j], Numeros[i]);
                }
            }
            foreach (int numero in Numeros)
                Pinta(numero);
        }
        // TODO: PINTA NOMES HA DE PINTAR NO DE CREAR
        private void Pinta(int numero)
        {
            Rectangle rect = new Rectangle();
            rect.Fill = Incorrecte;
            rect.Stroke = new SolidColorBrush(Colors.Black);
            rect.StrokeThickness = Gruix;
            rect.Width = 1000 / Length;
            rect.Height = 1000 * numero/Length;
            rect.RadiusX = CornerRadius;
            rect.RadiusY = CornerRadius;
            rect.SetValue(Canvas.LeftProperty, xOffset);
            rect.SetValue(Canvas.TopProperty, 0d);
            xOffset += rect.Width;
            Rectangles.Add(rect);
        }
    }
}
