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
            int[] ints = new int[10];
            p.CopyTo(ints, 5);
            foreach (int i in ints)
            {
                Console.WriteLine(i);
            }
        }
    }
}
