using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    internal class Equip : IComparable<Equip>
    {
        private string _nom;
        private int _golsF;
        private int _golsC;
        private int _punts;

        public Equip (string nom, int golsF, int golsC, int punts)
        {
            _nom = nom;
            _golsF = golsF;
            _golsC = golsC;
            _punts = punts;
        }

        public string Nom { get => _nom; set => _nom = value; }
        public int GolsF { get => _golsF; set => _golsF = value; }
        public int GolsC { get => _golsC; set => _golsC = value; }
        public int Punts { get => _punts; set => _punts = value; }

        public int CompareTo(Equip? other)
        {
            int result;
            if (other is not IComparable<Equip>) throw new ArgumentException("No es Comparable");
            if (other == null) result = 1;
            else result = Nom.CompareTo(other.Nom);
            return result;
        }

        public override string ToString()
        {
            string output = $"{_nom} PUNTS: {_punts}, GF: {_golsF}, GC: {_golsC} ";
            return output;
        }
        public class ComparadorPerGolsMarcats : IComparer<Equip>
        {
            int IComparer<Equip>.Compare(Equip? x, Equip? y)
            {
                int result;
                if (x is null || y is null) throw new Exception("No poden ser nulls");
                result = y.GolsF - x.GolsF;
                if (result==0 ) 
                {
                    result =x.CompareTo(y);
                }
                return result;
            }
        }
        public class ComparadorPerGolsEncaixats : IComparer<Equip>
        {
            int IComparer<Equip>.Compare(Equip? x, Equip? y)
            {
                int result;
                if (x is null || y is null) throw new Exception("No poden ser nulls");
                result = y.GolsC - x.GolsC;
                if (result == 0)
                {
                    result = x.CompareTo(y);
                }
                return result;

            }
        }
        public class ComparadorPerClassificacio : IComparer<Equip>
        {
            int IComparer<Equip>.Compare(Equip? x, Equip? y)
            {
                int result;
                if (x is null || y is null) throw new Exception("No poden ser nulls");
                result = y.Punts - x.Punts;
                if (result == 0) 
                {
                    if ((y.GolsF - y.GolsC) > (x.GolsF - x.GolsC))
                        result = 1;
                    if ((y.GolsF - y.GolsC) < (x.GolsF - x.GolsC))
                        result = -1;
                    else
                        result = 0;
                }
                if (result == 0)
                {
                    result = y.GolsF - x.GolsF;
                }
                if(result == 0)
                {
                    Random r = new Random();
                    result = r.Next(-1, 2);
                }
                return result;
            }
        }

    }
}
