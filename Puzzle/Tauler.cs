using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Puzzle
{
    public class Tauler:Grid
    {
        private int nFiles;
        private int nColumnes;
        private int[] casellaBuida = new int[2];
        private bool estaSolucionat;

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
                nFiles = value;
                ConfiguraColumnes();
            }
        }
        public int[] CasellaBuida { get => casellaBuida; set => casellaBuida = value; }
        public bool EstaSolucionat { get => estaSolucionat; set => estaSolucionat = value; }

        public Tauler() 
        {
            Inicialitza();
        }

        private void Inicialitza()
        {
            int aux = 0;
            int solucionats = 0;
            int[] peces = Peces();
            for (int i = 0; i<NFiles; i++)
            {
                for(int j=0; j<NColumnes; j++)
                {
                    Casella current = new Casella(aux);
                    current.Fila = i;
                    current.Columna = j;
                    if (aux == NFiles*NColumnes-2)
                    {
                        current.Text = "";
                    }
                    current.Text = peces[aux].ToString(); 
                    if (current.EstaBenColocada) 
                        solucionats++;
                }
            }
            if (solucionats == NFiles * NColumnes - 1)
                estaSolucionat = true;
            //TODO: es resoluble
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

    }
}
