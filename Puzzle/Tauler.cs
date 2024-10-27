using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Puzzle
{
    public class Tauler:Grid
    {
        private int nFiles=0;
        private int nColumnes=0;
        private int[] casellaBuida = new int[2];
        private bool estaSolucionat = false;
        private string time;
        private int moves=0;

        public string BenColocades
        {
            get
            {
                int totes = this.Children.Count;
                int be = 0;
                foreach (Casella c in this.Children) 
                {
                    if (c.EstaBenColocada)
                        be++;
                }
                if (totes == 1)
                    return "";
                else
                return $"{be}/{totes-1}";
            }
        }
        
        
        public string Time
        {
            get { return time; } set 
            {
                time = value;
            }
        }

        public int NFiles
        {
            get { return nFiles; }
            set
            {
                nFiles = value;
                ConfiguraFiles();
            }
        }

        public int NColumnes
        {
            get { return nColumnes; }
            set
            {
                nColumnes = value;
                ConfiguraColumnes();
            }
        }
        public int[] CasellaBuida { get => casellaBuida; set => casellaBuida = value; }
        public bool EstaSolucionat { get => estaSolucionat; set => estaSolucionat = value; }
        public int Moves { get => moves; set => moves = value; }

        public Tauler(int nFiles, int nColumnes) 
        {
            NFiles = nFiles; NColumnes = nColumnes;
            Inicialitza();
        }

        private void Inicialitza()
        {
            int aux = 0;
            int solucionats = 0;
            moves = 0;
            //Llenar random numeros
            int[] peces = Peces();
            if (Desordres(peces)%2!=0)
            {
                aux = peces[peces.Length-2];
                peces[peces.Length-2] = peces[peces.Length-1];
                peces[peces.Length-1] = aux;
                
            }
            aux = 0;
            //Llenar tablero de piezas
            for (int i = 0; i<NFiles; i++)
            {
                for(int j=0; j<NColumnes; j++)
                {
                    if (aux <= NFiles * NColumnes - 2)
                    {
                        Casella current = new Casella();
                        current.Fila = i;
                        current.Columna = j;
                        current.ValorActual = peces[aux];
                        current.ValorDesitjat = aux+1;
                        current.Text=current.ValorActual.ToString();
                        if (current.EstaBenColocada)
                            solucionats++;
                        aux++;
                        current.EsVisible = true;
                        current.SetValue(Grid.RowProperty, i);
                        current.SetValue(Grid.ColumnProperty, j);
                        this.Children.Add(current);
                        current.MouseDown += Current_MouseDown;
                    }        
                    else
                    {
                        Casella current = new Casella();
                        current.Fila = i;
                        current.Columna = j;
                        current.Text = "";
                        current.ValorDesitjat = aux + 1;
                        current.SetValue(Grid.RowProperty, i);
                        current.SetValue(Grid.ColumnProperty, j);
                        current.EsVisible = false;
                        current.Visibility = Visibility.Hidden;
                        this.Children.Add(current);
                        casellaBuida = [i,j];
                        current.MouseDown += Current_MouseDown;

                    }
                }
            }
            if (solucionats >= NFiles * NColumnes - 1)
            {
                solucionats = 0;
                this.Children.Clear();
                Inicialitza();
            }
        }

        private void Current_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            Casella current = (Casella)sender;
            if (MouFitxa(current))
            {
                estaSolucionat = true;
                MessageBox.Show("Has Guanyat");
                this.Children.Clear();
                Reset();
                Casella t = new Casella();
                t.Text = Time;
                Border marc = (Border)(t.Content);
                Viewbox vbox = (Viewbox)marc.Child;
                TextBlock text = (TextBlock)vbox.Child;
                marc.Background = Casella.pinzellFonsCorrecte;
                text.Foreground = Casella.pinzellLletraCorrecte;
                this.Children.Add(t);
            }
        }

        private bool MouFitxa(Casella current)
        {
            while (!estaSolucionat && current.EsVisible)
            {
                var buida = this.Children.Cast<Casella>()
                 .First(e => Grid.GetRow(e) == casellaBuida[0] && Grid.GetColumn(e) == casellaBuida[1]);
                if (!buida.Iguals(current))
                {
                    if (current.Columna == buida.Columna)
                    {
                        if (buida.Fila > current.Fila)
                        {
                            var contigua = this.Children.Cast<Casella>()
                                .First(e => Grid.GetRow(e) == casellaBuida[0] - 1 && Grid.GetColumn(e) == casellaBuida[1]);
                            Swap(contigua, buida);
                        }
                        if (buida.Fila < current.Fila)
                        {
                            var contigua = this.Children.Cast<Casella>()
                                    .First(e => Grid.GetRow(e) == casellaBuida[0] + 1 && Grid.GetColumn(e) == casellaBuida[1]);
                            Swap(contigua, buida);
                        }
                    }
                    else if (current.Fila == buida.Fila)
                    {
                        if (buida.Columna > current.Columna)
                        {
                            var contigua = this.Children.Cast<Casella>()
                            .First(e => Grid.GetRow(e) == casellaBuida[0] && Grid.GetColumn(e) == casellaBuida[1] - 1);
                            Swap(contigua, buida);
                        }
                        if (buida.Columna < current.Columna)
                        {
                            var contigua = this.Children.Cast<Casella>()
                            .First(e => Grid.GetRow(e) == casellaBuida[0] && Grid.GetColumn(e) == casellaBuida[1] + 1);
                            Swap(contigua, buida);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    //IMPORTANTE LIMPIAR ANTES DE REINICIAR
                    this.Children.Clear();
                    Inicialitza();
                }
            }
            if (!estaSolucionat) moves++;
            return Win();
        }
        private bool Win()
        {
            int be = 0;
            foreach (Casella e in this.Children) 
            {
                if (e.EstaBenColocada)
                    be++;           
            }
            return be == Children.Count - 1;
        }
        private void ConfiguraFiles()
        {
            for (int i = 0; i < NFiles; i++)
            {
                RowDefinitions.Add(new RowDefinition());
            }
        }
        private void ConfiguraColumnes()
        {
            for (int i = 0; i < NColumnes; i++)
            {
                ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        private void Reset()
        {
            RowDefinitions.Clear();
            ColumnDefinitions.Clear();
            RowDefinitions.Add(new RowDefinition());
            ColumnDefinitions.Add(new ColumnDefinition());

        }

        private int[] Peces()
        {
            List<int> result = Enumerable.Range(1, (NFiles * NColumnes)-1).ToList();
            Shuffle<int>(result);
            return result.ToArray();

        }
        public static void Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        private void Swap(Casella current, Casella buida)
        {
            buida.ValorActual = current.ValorActual;
            buida.Text = current.Text;
            current.EsVisible = false;
            buida.Visibility = Visibility.Visible;
            buida.EsVisible = true;
            current.Visibility = Visibility.Hidden;
            buida.EstaBenColocada = buida.ValorActual == buida.ValorDesitjat;
            this.casellaBuida = [current.Fila, current.Columna];
        }

        static int Desordres(int[] numeros)
        {
            int desordres = 0;
            for (int i = 0; i < numeros.Length - 1; i++)
            {
                for (int j = i + 1; j < numeros.Length; j++)
                {
                    if (numeros[j] != 0 && numeros[i] != 0
                        && numeros[i] > numeros[j])
                        desordres++;
                }
            }
            return desordres;
            
        }
    }

}
