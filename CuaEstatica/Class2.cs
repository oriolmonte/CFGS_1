using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaEstatica
{
    public class QEnumerator<T> : IEnumerator<T>, IEnumerator
    {
        private T[] dades;
        private int front;
        private int posCursor;
        public QEnumerator(T[]dades, int front)
        {
            this.dades = dades;
            this.front = front;
            posCursor = front+1;
            
        }

        public T Current => this.dades[posCursor];
        object IEnumerator.Current => Current;

        void IDisposable.Dispose()
        {
            dades = null;
        }

        bool IEnumerator.MoveNext()
        {
            bool hasNext = true;
            if (posCursor > 0) posCursor--;
            else hasNext = false;
            return hasNext;
        }

        void IEnumerator.Reset()
        {
            posCursor = front+1;
        }
    }
}
