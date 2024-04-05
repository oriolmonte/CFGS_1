using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilaDinamica
{
    public class Node<T>
    {
        private T info;
        private Node<T> next = null;

        public T Info { get => info; set => info = value; }
        public Node<T> Next { get => next; set => next = value; }

        public Node(T info)
        {
            this.info = info;
        }        
    }
}
