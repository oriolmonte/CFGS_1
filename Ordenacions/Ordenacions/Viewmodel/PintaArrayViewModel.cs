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

namespace Ordenacions.Viewmodel
{   
    

    public partial class PintaArrayViewModel : ObservableObject
    {
        static ObservableCollection<string> figures = ["Barres", "Punts"];
        static ObservableCollection<string> ordenacions = ["Bubble Sort", "Cocktail Sort", "Quick Sort"];
        [ObservableProperty]
        ObservableCollection<string> opcionsFigures = figures;
        [ObservableProperty]
        ObservableCollection<string> opcionsOrdenacions = ordenacions;
        [ObservableProperty]
        Color colorFons = Colors.White;
        partial void OnColorFonsChanged(Color oldValue, Color newValue)
        {
            Fons.Color = newValue;
        }

        [ObservableProperty]
        Color colorCorrecte = Colors.Green;
        partial void OnColorCorrecteChanged(Color oldValue, Color newValue)
        {
            Correcte.Color = newValue;
        }
        [ObservableProperty]
        Color colorIncorrecte = Colors.Red;
        partial void OnColorIncorrecteChanged(Color oldValue, Color newValue)
        {
            Incorrecte.Color = newValue;
        }

        [ObservableProperty]
        Color colorIntercanvi = Colors.Yellow;
        partial void OnColorIntercanviChanged(Color oldValue, Color newValue)
        {
            Intercanvi.Color = newValue;
        }

        [ObservableProperty]
        int length;
        partial void OnLengthChanged(int value)
        {
            if (value < 0)
                Length = 3;
            if (value > MaxValue)
                Length = MaxValue;
            Crea();
        }
        [ObservableProperty]
        List<int> numeros;
        [ObservableProperty]
        ObservableCollection<Rectangle> rectangles;
        [ObservableProperty]
        ObservableCollection<Ellipse> circles;
        [ObservableProperty]
        int gruix;
        partial void OnGruixChanged(int value)
        {
            Crea();
        }
        [ObservableProperty]
        int cornerRadius;
        partial void OnCornerRadiusChanged(int value)
        {
            Crea();
        }
        [ObservableProperty]
        int tempsEspera;
        [ObservableProperty]
        bool aleatori = true;
        partial void OnAleatoriChanged(bool value)
        {
            Crea();
        }
        partial void OnInvertitChanged(bool value)
        {
            Crea();
        }
        static int MaxValue = 1000;
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
        partial void OnFonsChanged(SolidColorBrush value)
        {
            Crea();
        }
        [ObservableProperty]
        SolidColorBrush correcte = new SolidColorBrush(Colors.Green);
        partial void OnCorrecteChanged(SolidColorBrush? oldValue, SolidColorBrush newValue)
        {
            Crea();
        }
        [ObservableProperty]
        SolidColorBrush incorrecte = new SolidColorBrush(Colors.Red);
        partial void OnIncorrecteChanged(SolidColorBrush? oldValue, SolidColorBrush newValue)
        {
            Crea();
        }
        [ObservableProperty]
        SolidColorBrush intercanvi = new SolidColorBrush(Colors.Yellow);
        [ObservableProperty]
        private string selectedFigura;
        partial void OnSelectedFiguraChanged(string? oldValue, string newValue)
        {
            Crea();
        }
        [ObservableProperty]
        private string selectedOrdenacions;

        public PintaArrayViewModel()
        {
            length = 5;
            numeros = new List<int>();
            rectangles = new ObservableCollection<Rectangle>();
            circles = new ObservableCollection<Ellipse>();
            gruix = 2;
            cornerRadius = 5;
            tempsEspera = 100;
            selectedFigura = opcionsFigures[0];
            selectedOrdenacions = opcionsOrdenacions[0];
            Crea();
        }
        [RelayCommand]
        private void Crea()
        {
            xOffset = 0;
            Numeros.Clear();
            Rectangles.Clear();
            if(Circles!=null)
                Circles.Clear();
            if (Invertit)
            {
                for(int i = Length; i>=1; i--)
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
                if(SelectedFigura  == figures[0])
                    CreaRectangle(Numeros[i], BenColocat(Numeros, i));
                if (SelectedFigura == figures[1])
                    CreaCircle(Numeros[i], BenColocat(Numeros, i));
            }
        }
        // TODO: PINTA NOMES HA DE PINTAR NO DE CREAR
        private void CreaRectangle(int numero, bool correcte)
        {
            Rectangle rect = new Rectangle();
            if (correcte)
                rect.Fill = Correcte;
            else
                rect.Fill = Incorrecte;
            rect.Stroke = new SolidColorBrush(Colors.Black);
            rect.StrokeThickness = Gruix;
            rect.Width = 1000 / Length;
            rect.Height = 1000 * numero / Length;
            rect.RadiusX = CornerRadius;
            rect.RadiusY = CornerRadius;
            rect.SetValue(Canvas.LeftProperty, xOffset);
            rect.SetValue(Canvas.BottomProperty, 0d); 
            xOffset += rect.Width;
            Rectangles.Add(rect);
        }
        private void CreaCircle(int numero, bool correcte)
        {
            Ellipse circle = new Ellipse(); 

            if (correcte)
                circle.Fill = Correcte;
            else
                circle.Fill = Incorrecte;

            circle.Stroke = new SolidColorBrush(Colors.Black);
            circle.StrokeThickness = Gruix;

            circle.Width = 1000 / Length;
            circle.Height = circle.Width;
            double topPosition = (1000 - circle.Height) * (1 - (double)numero / Length);

            circle.SetValue(Canvas.LeftProperty, xOffset); 
            circle.SetValue(Canvas.TopProperty, topPosition);

            xOffset += circle.Width; 

            Circles.Add(circle);
        }

        //TRIA L'ORDENACIO
        [RelayCommand]
        private async void Ordena()
        {
            if (SelectedOrdenacions == ordenacions[0])
                await BubbleSort(Numeros);
            else if(SelectedOrdenacions == ordenacions[1])
                {
                await CocktailSort(Numeros);
            }
            else
                await QuickSort(Numeros,0,Numeros.Count-1);
            Final();
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
                        await Swap(list, j, j + 1);
                    }
                }
            }
        }

        async Task Swap(List<int> list, int index1, int index2)
        {
            //BARRES
            if (SelectedFigura == figures[0])
            {
                if (MarcaIntercanvis)
                {
                    Rectangles[index1].Fill = Intercanvi;
                    Rectangles[index2].Fill = Intercanvi;

                }
                double tempHeight = Rectangles[index1].Height;
                Rectangles[index1].Height = Rectangles[index2].Height;
                Rectangles[index2].Height = tempHeight;
                int temp = list[index1];
                list[index1] = list[index2];
                list[index2] = temp;
                await Task.Delay(TempsEspera);
                if (BenColocat(Numeros, index1))
                    Rectangles[index1].Fill = Correcte;
                else
                    Rectangles[index1].Fill = Incorrecte;
                if (BenColocat(Numeros, index2))
                    Rectangles[index2].Fill = Correcte;
                else
                    Rectangles[index2].Fill = Incorrecte;
            }
            //CERCLES
            else
            {
                if (MarcaIntercanvis)
                {
                    Circles[index1].Fill = Intercanvi;
                    Circles[index2].Fill = Intercanvi;

                }
                double tempHeight = (double)Canvas.GetTop(Circles[index1]);
                Circles[index1].SetValue(Canvas.TopProperty,Canvas.GetTop(Circles[index2]));
                Circles[index2].SetValue(Canvas.TopProperty, tempHeight);
                int temp = list[index1];
                list[index1] = list[index2];
                list[index2] = temp;
                await Task.Delay(TempsEspera);
                if (BenColocat(Numeros, index1))
                    Circles[index1].Fill = Correcte;
                else
                    Circles[index1].Fill = Incorrecte;
                if (BenColocat(Numeros, index2))
                    Circles[index2].Fill = Correcte;
                else
                    Circles[index2].Fill = Incorrecte;
            }

        }
        private async Task CocktailSort(List<int> list)
        {
            bool swapped = true;
            int start = 0;
            int end = list.Count - 1;

            while (swapped)
            {
                swapped = false;


                for (int i = start; i < end; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        await Swap(list, i, i + 1);
                        swapped = true;

                    }
                }

                if (!swapped)
                    return;

                swapped = false;
                end--;


                for (int i = end - 1; i >= start; i--)
                {
                    if (list[i] > list[i + 1])
                    {
                        await Swap(list, i, i + 1);
                        swapped = true;

                    }
                }

                start++;
            }
        }

        private async Task QuickSort(List<int> list, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = await Partition(list, low, high);
                await QuickSort(list, low, pivotIndex - 1);  // Sort left of pivot
                await QuickSort(list, pivotIndex + 1, high); // Sort right of pivot
            }
        }

        private async Task<int> Partition(List<int> list, int low, int high)
        {
            int pivot = list[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (list[j] < pivot)
                {
                    i++;
                    await Swap(list, i, j);


                }
            }
            await Swap(list, i + 1, high);
            return i + 1;
        }

        private bool BenColocat(List<int> list, int index)
        {
            
            if (index > 0 && list[index] < list[index - 1])
            {
                return false;
            }

            if (index < list.Count - 1 && list[index] > list[index + 1])
            {
                return false;
            }

            return true;
        }
        private async Task Final()
        {
            if (SelectedFigura == figures[0])
            {
                foreach (Rectangle r in Rectangles)
                {
                    r.Fill = Intercanvi;
                    if (Length < 20)
                        await Task.Delay(75);
                    else if (Length < 50)
                        await Task.Delay(20);
                    else
                        await Task.Delay(5);
                }
                foreach (Rectangle r in Rectangles)
                {
                    r.Fill = Correcte;
                }
            }
            else
            {
                foreach (Ellipse r in Circles)
                {
                    r.Fill = Intercanvi;
                    if (Length < 20)
                        await Task.Delay(75);
                    else if (Length < 50)
                        await Task.Delay(20);
                    else
                        await Task.Delay(5);
                }
                foreach (Ellipse r in Circles)
                {
                    r.Fill = Correcte;
                }

            }
        }
    }
}
