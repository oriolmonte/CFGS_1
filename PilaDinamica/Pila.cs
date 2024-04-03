using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilaDinamica
{
    public class Pila<T> : IEnumerable<T>, IEnumerable, IList<T> //TODO TOSTRING, EQUALS, GET ENUMERATOR NORMAL
    {
        private Node<T> top = null;
        private bool isReadOnly;
        public Pila()
        {
        }
        public Pila(T input)
        {
            top = new Node<T>(input);
        }
        bool Empty
        {
            get { return top == null; }
        }
        public Node<T> Top
        {
            get { return top; }
        }

        int ICollection<T>.Count
        {
            get
            {
                int count = 0;
                foreach (T item in this) { count++; }
                return count;
            }
        }

        bool ICollection<T>.IsReadOnly { get => isReadOnly;} 

        T IList<T>.this[int index] 
        { 
            
            get
            {
                Node<T> cursor = null;
                IEnumerator<T> enumerator = GetEnumerator();
                for (int i = 0; i<index;index++)
                {
                    enumerator.MoveNext();
                }

            }
        }

        public void Push (T item)
        {
            Node<T> node = new Node<T>(item);
            if (!Empty)
            {
                node.Next = top;
                top = node;
            }
            else
            {
                top = node;
            }
        }
        public T Pop()
        {
            if (!Empty)
            {
                T dada = top.Info;
                if (top.Next != null)
                {
                    Node<T> tmp = top;
                    top = top.Next;
                    tmp.Next = null;
                }
                else
                    top = null;
                return dada;
            }
            else throw new Exception("STACK UNDERFLOW");
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> cursor = top;
            while (cursor!= null)
            {
                yield return cursor.Info;
                cursor = cursor.Next;
            }

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();

        }

        int IList<T>.IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        void IList<T>.Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        void IList<T>.RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.Add(T item)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Contains(T item)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotImplementedException();
        }
    }
}
