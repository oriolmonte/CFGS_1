using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StarterTeclatMouseControlsDinamics
{
    public class Graella : Grid
    {
        private int nFiles = 0;
        public int NFiles
        {
            get { return nFiles; }
            set { 
                nFiles = value;
                ConfiguraFiles();
            }
        }

        public Graella()
        {
            ShowGridLines=true;
        }

        private void ConfiguraFiles()
        {
            if (nFiles>RowDefinitions.Count)
            {
                for (int fila = RowDefinitions.Count; fila<NFiles; fila++) 
                {
                    RowDefinitions.Add(new RowDefinition());
                    ColumnDefinitions.Add(new ColumnDefinition());
                }
            }
            else if (nFiles<RowDefinitions.Count)
            {
                for(int fila = 0; fila<RowDefinitions.Count-NFiles; fila++)
                {
                    RowDefinitions.RemoveAt(0);
                    ColumnDefinitions.RemoveAt(0);
                }
            }
        }
    }
}
