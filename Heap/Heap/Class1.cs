using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stack
{
    public class Pila<T>
    {
        private const int MIDA_DEFAULT = 10;
        private T[] _dades;
        private int _nelements;

        public Pila()
        {
            _dades = new T[MIDA_DEFAULT];
            _nelements = 0;
        }
        public Pila(int mida)
        {
            _dades = new T[mida];
            _nelements = 0;
        }
        public Pila(Pila<T> stack)
        {
            _dades = new T[stack._dades.Length];
            for (int i = 0; i < _dades.Length; i++)
            {
                _dades[i] = stack._dades[i];
            }
            _nelements = stack._nelements;
        }
        public void Empila(T value)
        {
            if (!EsPlena)
            {
                _dades[_nelements] = value;
                _nelements++;
            }
            else
            {
                throw new Exception("Stack Overflow");
            }
        }
        public T Desempila()
        {
            if (EsBuida) throw new Exception("Empty");
            T desempilat = _dades[_nelements - 1];
            _dades[_nelements - 1] = default;
            _nelements--;
            return desempilat;

        }
        public bool EsPlena
        {
            get
            {
                bool full = false;
                if (_nelements.Equals(_dades.Length))
                {
                    full = true;
                }
                return full;
            }
        }
        public bool EsBuida
        {
            get
            {
                return _nelements == 0;
            }

        }
        public T Cim
        {

            get
            {
                if (!EsBuida)
                    return _dades[_nelements - 1];
                else
                    throw new Exception("Stack Underflow");

            }

        }
        public override string ToString()
        {
            //Capacitat: 
            StringBuilder sb = new StringBuilder();
            if (this is null) throw new NullReferenceException("Llista nula");
            if (!EsBuida)
            {
                if (!EsPlena)
                {
                    sb.Append($"Capacitat {_nelements}/{_dades.Length}:");
                }
                else
                {
                    sb.Append($"Pila plena:");
                }
                sb.Append("-");
                for (int i = _nelements - 1; i >= 0; i--)
                {
                    sb.Append(_dades[i].ToString());
                    sb.Append("-");
                }

            }
            else
            {
                sb.Append("Pila buida:-");
            }
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            bool areEqual = true;
            if (this is null) areEqual = false;
            else if (obj is Pila<T>)
            {
                Pila<T> entrada = new Pila<T>((Pila<T>)obj);
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

