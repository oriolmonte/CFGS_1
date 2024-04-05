using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilaDinamica
{
    public class Pila<T> : IEnumerable<T>, IEnumerable, IList<T> 
    {
        private Node<T> top = null;
        private bool isReadOnly = false;
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

        public int Count
        {
            get
            {
                int count = 0;
                foreach (T item in this) { count++; }
                return count;
            }
        }

        public bool IsReadOnly { get => isReadOnly;}

        public T this[int index] 
        { 
            
            get
            {
                if(index < 0 || index >= Count) throw new ArgumentOutOfRangeException("index");
                Node<T> node = GetNodeAt(index);
                return node.Info;
                
            }
            set
            {
                if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException("index");
                if (isReadOnly) throw new NotSupportedException();
                Node<T> node = GetNodeAt(index);
                node.Info = value;
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

        public int IndexOf(T item)
        {
            
            int contador = 0;
            bool trobat = false;
            
            IEnumerator enumerador = GetEnumerator();
            while (enumerador.MoveNext() && !trobat) 
            {
                if(enumerador.Current.Equals(item))
                    trobat = true;

            }
            return contador;
        }
        
        private Node<T> GetNodeAt(int index)
        {
            Node<T> cursor = top;
            if (index < 0 || index >= Count) cursor = null;
            else
            {
                for (int i = 0; i < index; i++)
                {
                    cursor = cursor.Next;
                }
            }
            return cursor;
        }
        public void Insert(int index, T item)
        {
            if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException("index");
            if (isReadOnly) throw new NotSupportedException();
            Node<T> itemN = new Node<T>(item);
            if (index == 0)
                Push(item);
            else if (index == Count-1)
            {
                GetNodeAt(index).Next = itemN;
            }
            else
            {
                Node<T> antNode = GetNodeAt(index-1);
                Node<T> node = antNode.Next;
                antNode.Next = itemN;
                itemN.Next = node;
            }
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException("index");
            if (isReadOnly) throw new NotSupportedException();
            if (index == 0)
            {
                Pop();
            }
            else if (index == Count - 1)
            {
                Node<T> a = GetNodeAt(index-1);
                a.Next=null;
            }
            else
            {
                Node<T> antNode = GetNodeAt(index - 1);
                Node<T> segNode = antNode.Next.Next;
                antNode.Next = segNode;
            }
        }
        public void Add(T item)
        {
            if (isReadOnly) throw new NotSupportedException();
            Push(item);
        }

        public void Clear()
        {
            int countIni = Count;
            if (isReadOnly) throw new NotSupportedException();
            for (int i =0; i<countIni; i++) 
            {
                Pop();
            }
        }

        public bool Contains(T item)
        {
            bool a = false;
            if(IndexOf(item)!=-1) a = true;
            return a;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if(array == null) throw new ArgumentNullException("array");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("no valid index");
            if (array.Length - arrayIndex < Count) throw new ArgumentException("No cap la pila a dins l'array");
            for(int i = 0; i < Count; i++)
            {
                array[arrayIndex+i] = this[i];
            }
        }

        public bool Remove(T item)
        {
            if (isReadOnly) throw new NotSupportedException();
            bool result;
            int index = IndexOf(item);
            if (index != -1)
            {
                RemoveAt(index);
                result = true;
            }
            else { result= false; }
            return result;
        }
        public override bool Equals(object? obj)
        {
            bool areEqual = true;
            bool end = false;
            if (this is null) areEqual = obj is null;
            else if ( obj is Pila<T> otherPila)
            {
                if (!this.Count.Equals(otherPila.Count)) areEqual = false;
                else
                {
                    Node<T> thisNode = this.top;
                    Node<T> otherNode = otherPila.top;

                    while (areEqual && !end)
                    {
                        areEqual = thisNode.Info.Equals(otherNode.Info);
                        thisNode = thisNode.Next; otherNode = otherNode.Next;
                        if (thisNode is null && otherNode is null)
                            end = true;
                    }
                }
            }
            return areEqual;
        }
        public override string ToString()
        {
            string outp;
            if (!Empty)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("[");
                foreach (T item in this)
                {
                    sb.Append($"{item},");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("]");
                outp = sb.ToString();
            }
            else outp = "EMPTY";
            return outp;
        }
        
    }
}
