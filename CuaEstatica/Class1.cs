using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaEstatica
{
    public class Queue<T> : IEnumerable<T>, IEnumerable
    {
        private T[] data;
        private int front = -1;
        
        const int DEFAULT_SIZE = 10;
        public Queue() 
        {
            data = new T[DEFAULT_SIZE];
        
        }
        public Queue(int mida)
        {
            data = new T[mida];
        
        }
        public bool Full
        {
           get { return front==data.Length-1; }
        }
        public int Count
        {
            get { return front+1; }
        }
        public T this[int index]
        {
            get
            {
                if(index<0 || index > front) throw new IndexOutOfRangeException();
                return data[index];
            }
        }
        public T DeQueue()
        {
            if(Empty) throw new IndexOutOfRangeException();
            T result = data[front];
            data[front] = default;
            front--;
            return result;
        }
        public T Peek()
        {
            if (Empty) throw new IndexOutOfRangeException();
            T result = data[front];
            return result;
        }
        public void Enqueue(T item)
        {
            if(Full) throw new IndexOutOfRangeException();
            for(int i = front+1; i>0; i--) 
            {
                T aux = data[i];
                data[i] = data[i - 1];
                data[i - 1] = aux;
            }
            data[0] = item;
            front++;
        }
        public void Enqueue(IEnumerable<T> items)
        {
            foreach(T item in items)
            {
                Enqueue(item);
            }
        }
        public T[] ToArray()
        {
            int i = 0;
            T[] result = new T[front+1];
            foreach(T item in this) 
            {
                result[i++] = item;
            }
            return result;
        }
        public bool Contains(T item)
        {
            IEnumerator<T> enumer = this.GetEnumerator();
            bool result = false;
            while (enumer.MoveNext() && !result)
            {
                result = item.Equals(enumer.Current);
            }
            return result;
        }
        public Queue<T> Requeue()
        {
            Queue<T> result = new Queue<T>(data.Length);
            Queue<T> tail = new Queue<T>(data.Length);
            for(int i = 0; i<(this.front+1)/2;i++)
            {
                result.data[i] = this.data[i];      
                result.front++;
            }
            int frontFix = front;
            if (frontFix%2!=0) 
            {
                for (int i = 0; i < (frontFix + 1) / 2; i++)
                {
                    tail.Enqueue(this.DeQueue());
                }
            }
            else
            {
                for (int i = 0; i < (frontFix + 1) / 2+1; i++)
                {
                    tail.Enqueue(this.DeQueue());
                }
            }
            
            this.data = tail.data;
            this.front = tail.front;
            return result;
        }
        public override string ToString()
        {
            if (Empty) throw new Exception("Is Empty");
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            //for(int i = 0; i <= front; i++) 
            //{
            //    sb.Append(data[i].ToString() + ",");
            //}
            foreach(T item in this) 
            {
                sb.Append(item.ToString() + ",");
            }
            sb.Remove(sb.Length-1,1);
            sb.Append("]");
            return sb.ToString();
        }
        public bool Empty
        {
            get { return front == - 1; }
        }
        public IEnumerator<T> GetEnumerator()
        {
            //for(int i = front;i>=0;i--)yield return data[i];
            return new QEnumerator<T>(this.data, this.front);
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return  this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
            
        }
        public IEnumerator<T> GetEnumeratorYield()
        {
            for (int i = front; i >= 0; i--) yield return data[i];
        }
    }
}
