using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArrayList
{
    //TODO: Fer generic
    public class TaulaLlista<T>
    {
        private T[] _dades;
        private int _nelements;
        const int MIDA_DEFAULT = 10;
        public TaulaLlista(int mida)
        {
            _dades = new T[mida];
            _nelements = 0;
        }

        public TaulaLlista() 
        {
            _dades = new T[MIDA_DEFAULT];
            _nelements = 0;
        }
        public TaulaLlista(TaulaLlista<T> t)
        {
            if (t is null) throw new NullReferenceException("La taula parametre no pot ser null");
            T[] objects = new T[t.Capacitat];
            _nelements = t._nelements;
            for(int i=0;i<t._nelements; i++) 
            {
                objects[i] = t._dades[i];
            }
            _dades = objects;
        }
        public int Afegeix(T element)
        {
            //Si ens quedem sense espai dupliquem la taula
            if (element is null) throw new ArgumentNullException("NO POTS AFEGIR NULLS");
            if(Capacitat<=_nelements) DoubleCapacity();
            _dades[_nelements] = element;
            _nelements++;
            return _nelements-1;
        }
        public void AfegeixRang(T[] array)
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
            T[] dadescopia = new T[_dades.Length * 2];
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
                _dades[i] = default;
            }
            _nelements = 0;

        }
        public void EliminaAt(int posicio)
        {
            if (posicio > _nelements) throw new IndexOutOfRangeException("HAS INTENTAT INSERIR FORA DE LA TAULALLISTA");
            if (posicio < 0) throw new IndexOutOfRangeException("HAS INTENTAT INSERIR FORA DE LA TAULALLISTA");
            _dades[posicio] = default;
            if (posicio != _nelements-1)
            {
                for (int i = posicio + 1; i < _nelements; i++)
                {
                    _dades[i - 1] = _dades[i];
                }
                _dades[_nelements - 1] = default;
            }
            _nelements--;
        }
        public bool Elimina(T element)
        {
            bool eliminat = true;
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
        public void Insereix(T element, int posicio)
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
        public int IndexDe(T element)
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
        public int ultimIndexDe(T element)
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
        public bool Conte(T element)
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
            T aux = default;
            for (int i = 0; i < _nelements / 2; i++)
            {
                aux = _dades[i];
                _dades[i] = _dades[_nelements - 1 - i];
                _dades[_nelements - 1 - i] = aux;
            }
        }
        public T PrimerMenorQue(T valor)
        {
            
            if (valor is not IComparable<T>) throw new Exception("No es comparable");
            else
            {
                T result;
                IComparable<T> valorC = (IComparable<T>) valor;
                int i = 0;
                bool trobat = false;
                while (!trobat && i<_nelements)
                {

                    if (valorC.CompareTo(_dades[i]) > 0)
                        trobat = true;
                    else
                        i++;
                }
                if (!trobat) result = default;
                else
                    result = _dades[i];
                return result;
            }
        }
        public void Sort()
        {
            T[] values = ToArray();
            if (values[0] is not IComparable<T>) throw new Exception("No son comparables");
            else
                Array.Sort(values);
            _dades = values;
        }
        public void Sort(IComparer<T> comparer)
        {
            T[] values = ToArray();
            if (values[0] is not IComparable<T>) throw new Exception("No son comparables");
            else
                Array.Sort(values, comparer);
            _dades = values;
        }


        public int Capacitat
        {
            get { return _dades.Length; }
        }
        public int NElems
        {
            get { return _nelements; }
        }
        public T this[int index]
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
        public T[] ToArray()
        {
            T[] result = new T[NElems];
            for(int i = 0; i < _nelements; i++)
            {
                result[i] = _dades[i];
            }
            return result;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            for(int i = 0; i<_nelements; i++)
            {
                stringBuilder.Append($"{_dades[i].ToString()},");
            }
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }
        public override bool Equals(object? obj)
        {
            bool areEqual = true;
            if (this is null) areEqual = false;
            else if (obj is TaulaLlista<T>)
            {
                TaulaLlista<T> entrada = new TaulaLlista<T>((TaulaLlista<T>)obj);
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
    
}
