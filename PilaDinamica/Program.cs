using System.Runtime.CompilerServices;

namespace PilaDinamica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pila<int> p = new Pila<int>();
            p.Push(1);
            p.Push(2);
            p.Push(3);
            p.Push(4);
            p.IndexOf(4);
            Console.WriteLine(p.IndexOf(4));
        }
    }
}
