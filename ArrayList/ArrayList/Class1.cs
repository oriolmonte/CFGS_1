using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArrayList
{
    public class TaulaLlista
    {
        private object[] _dades;
        private int _nelements;
        const int MIDA_DEFAULT = 10;
        public TaulaLlista(int mida)
        {
            _dades = new object[mida];
            _nelements = 0;
        }

        public TaulaLlista() 
        {
            _dades = new object[MIDA_DEFAULT];
            _nelements = 0;
        }
        public TaulaLlista(TaulaLlista t)
        {
            if (t is null) throw new NullReferenceException("La taula parametre no pot ser null");
            object[] objects = new object[t.Capacitat];
            _nelements = t._nelements;
            for(int i=0;i<t._nelements; i++) 
            {
                objects[i] = t._dades[i];
            }
            _dades = objects;
        }
        public int Afegeix(object element)
        {
            //Si ens quedem sense espai dupliquem la taula
            if (element is null) throw new ArgumentNullException("NO POTS AFEGIR NULLS");
            if(Capacitat<=_nelements) DoubleCapacity();
            _dades[_nelements] = element;
            _nelements++;
            return _nelements-1;
        }
        public void AfegeixRang(object[] array)
        {
            if (array==null) throw new ArgumentNullException("array es null");
            for(int i =0;i<array.Length;i++)
            {
                if (array[i]!=null)
                {
                    Afegeix(array[i]);
                }
            }
        }
        private void DoubleCapacity()
        {
            object[] dadescopia = new object[_dades.Length * 2];
            for (int i = 0; i < Capacitat; i++)
            {
                dadescopia[i] = _dades[i];
            }
            _dades = dadescopia;
        }
        public void Neteja()
        {
            for(int i = 0; i < _dades.Length;i++)
            {
                _dades[i] = null;
            }
            _nelements = 0;

        }
        public void EliminaAt(int posicio)
        {
            if (posicio > _nelements) throw new IndexOutOfRangeException("HAS INTENTAT INSERIR FORA DE LA TAULALLISTA");
            if (posicio < 0) throw new IndexOutOfRangeException("HAS INTENTAT INSERIR FORA DE LA TAULALLISTA");
            _dades[posicio] = null;
            if (posicio != _nelements-1)
            {
                for (int i = posicio + 1; i < _nelements; i++)
                {
                    _dades[i - 1] = _dades[i];
                }
                _dades[_nelements - 1] = null;
            }
            _nelements--;
        }
        public bool Elimina(object element)
        {
            bool eliminat =true;
            int index = IndexDe(element);
            if (index < 0)
            {
                eliminat = false;
            }
            else
            {
                EliminaAt(index); eliminat=true;
            }
            return eliminat;
        }
        public void Insereix(object element, int posicio)
        {
            if (posicio > _nelements) throw new IndexOutOfRangeException("HAS INTENTAT INSERIR FORA DE LA TAULALLISTA");
            if (element == null) throw new ArgumentNullException("NO INSEREIX NULL");
            if (posicio < 0) throw new IndexOutOfRangeException("HAS INTENTAT INSERIR FORA DE LA TAULALLISTA");
            while (Capacitat < _nelements+1)
            {
                DoubleCapacity();
            }
            for (int i = _nelements; i > posicio; i--)
            {
                _dades[i] = _dades[i - 1];
            }
            _nelements++;
            _dades[posicio] = element;
        }
        public int IndexDe(object element)
        {
            int index =0;
            bool trobat = false;
            while(!trobat && index < _nelements)
            {
                if (_dades[index].Equals(element))
                {
                    trobat = true;
                }
                else
                    index++;
            }
            if (!trobat)
                index = -1;
            return index;
        }
        public int ultimIndexDe(object element)
        {
            int index = _nelements-1;
            bool trobat = false;
            while (!trobat && index >= 0)
            {
                if (_dades[index].Equals(element))
                {
                    trobat = true;
                }
                else
                    index--;
            }
            if (!trobat)
                index = -1;
            return index;
        }
        public bool Conte(object element)
        {
            bool result = true;
            if (IndexDe(element) == -1)
            { 
                result = false;
            }
            return result;
        }
        public void Inverteix()
        {
            object aux = null;
            for (int i = 0; i < _nelements / 2; i++)
            {
                aux = _dades[i];
                _dades[i] = _dades[_nelements - 1 - i];
                _dades[_nelements - 1 - i] = aux;
            }
        }

        public int Capacitat
        {
            get { return _dades.Length; }
        }
        public int NElems
        {
            get { return _nelements; }
        }
        public object this[int index]
        {

            get {
                if (index < 0 || index >= NElems) throw new IndexOutOfRangeException("Index es invalid");
                return _dades[index]; 
            }
            set
            {
                if (index < 0 || index >= NElems) throw new IndexOutOfRangeException("Index es invalid");
                if(value is null) throw new ArgumentNullException("value IS NULL");
                _dades[index] = value;
            }
        }
        public object[] ToArray()
        {
            object[] result = new object[NElems];
            for(int i = 0; i < _nelements; i++)
            {
                result[i] = _dades[i];
            }
            return result;
        }
        public override string ToString()
        {
            if (this is null) throw new NullReferenceException("NO PODEM TRANSFORMAR LLISTES NULES");
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            for(int i = 0; i<_nelements; i++)
            {
                stringBuilder.Append($"{_dades[i]},");
            }
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }
        public override bool Equals(object? obj)
        {
            bool areEqual = true;
            if (this is null) areEqual = obj is null;
            else if (obj is TaulaLlista)
            {
                TaulaLlista entrada = new TaulaLlista((TaulaLlista)obj);
                if (_nelements != entrada._nelements) areEqual = false;
                else
                {
                    int i = 0;
                    while (areEqual && i < _nelements)
                    {
                        areEqual = _dades[i].Equals(entrada._dades[i]);
                        i++;
                    }
                }
            }
            else areEqual = false;
            return areEqual;
        }
    }
    public class Article
    {
        private int _codi;
        private string _desc;
        private double _preu;

        public Article()
        {
            _codi = 0;
            _desc = "";
            _preu = 0;
        }
        public Article(int codi, string desc, double preu)
        {
            _codi = codi;
            _desc = desc;
            _preu = preu;
        }
        public Article(Article c)
        :this(c._codi,c._desc,c._preu){

        }

        public int Codi
        {
            get { return _codi; }
            set { _codi = value; }
        }
        public string Desc
        {
            get { return _desc; }
            set { _desc = value; } 
        }
        public double Preu
        {
            get { return _preu; }
            set { _preu = value; }
        }
        public void IncrementarPreu(double increment)
        {
            Preu+=increment;
        }

    }
    public class Cercle
    {
        private double _x;
        private double _y;
        private double _radi;
        private double _preum2;

        public Cercle(double x, double y, double r, double preum2) 
        {
            _x = x;
            _y = y;
            _radi = r;
            _preum2 = preum2;
        }
        public double X
        {
            get { return _x; }
            set { _x = value; }
        }
        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public double Radi
        {
            get { return _radi; }
            set { _radi = value; }
        }
        public double Preu
        {
            get { return _preum2 * Math.PI * _radi * _radi; }
        }
    }
}
