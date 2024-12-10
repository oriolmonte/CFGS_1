using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            xOffset = 0;
            Numeros.Clear();
            Rectangles.Clear();
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
            for(int i = 0; i < Length; i++)
            {
                CreaRectangle(Numeros[i]);
            }
        }
        // TODO: PINTA NOMES HA DE PINTAR NO DE CREAR
        private void CreaRectangle(int numero)
        {
            Rectangle rect = new Rectangle();
            rect.Fill = Incorrecte;
            rect.Stroke = new SolidColorBrush(Colors.Black);
            rect.StrokeThickness = Gruix;
            rect.Width = 1000 / Length;
            rect.Height = 1000 * numero / Length;
            rect.RadiusX = CornerRadius;
            rect.RadiusY = CornerRadius;
            rect.SetValue(Canvas.LeftProperty, xOffset);
            rect.SetValue(Canvas.BottomProperty, 0d); // Desde el fondo hacia arriba
            xOffset += rect.Width;
            Rectangles.Add(rect);
        }

        [RelayCommand]
        private void Altera()
        {
            BubbleSort(Numeros);
        }
        private async Task BubbleSort(List<int> list)
        {
            int n = list.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        Swap(list, j, j + 1);
                        await Task.Delay(TempsEspera);
                    }
                }
            }
        }

        // Swap function
        private void Swap(List<int> list, int index1, int index2)
        {
            double tempHeight = Rectangles[index1].Height;
            Rectangles[index1].Height = Rectangles[index2].Height;
            Rectangles[index2].Height = tempHeight;
            int temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
