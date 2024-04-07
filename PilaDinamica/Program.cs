using System.Runtime.CompilerServices;
using System;

namespace PilaDinamica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Constructors, Propietats");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Constructor Buit");
            Pila<int> myPila = new Pila<int>();
            try
            {
            Console.WriteLine("Empty?: "+myPila.Empty);
            Console.WriteLine("Count?: "+myPila.Count);
            Console.WriteLine("Top?: "+myPila.Top);
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Constructor Parametre (1)");
            myPila = new Pila<int>(1);
            try
            {
            Console.WriteLine("Empty?: "+myPila.Empty);
            Console.WriteLine("Count?: "+myPila.Count);
            Console.WriteLine("Top?: "+myPila.Top.Info);
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Metodes basics");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Push");
            myPila.Push(2);
            Console.WriteLine(myPila);
            Console.WriteLine("Pop");
            myPila.Pop();
            Console.WriteLine(myPila);
            Console.WriteLine("Interficie List");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Clear");
            myPila.Clear();
            Console.WriteLine(myPila);
            Console.WriteLine("Creem pila de l'1 al 10");
            int[] ints = new int[10];
            for(int i = 0; i<ints.Length;i++)
            {
                ints[i]=i+1;
            }
            myPila.Push(ints);         
            Console.WriteLine(myPila);
            Console.WriteLine("IndexOf 4");
            Console.WriteLine(myPila.IndexOf(4));
            Console.WriteLine("Insertem un 5 a index 4");
            myPila.Insert(4,5);
            Console.WriteLine(myPila);
            Console.WriteLine("Mirem index 4");
            Console.WriteLine(myPila[4]);
            Console.WriteLine("Eliminem el 7");
            myPila.Remove(7);
            Console.WriteLine(myPila);
            Console.WriteLine("Comprovem si hi ha el 7");
            Console.WriteLine(myPila.Contains(7));
            Console.WriteLine("copiem a un int[20] a partir de [5]");
            int[] toCopyTo = new int[20];
            myPila.CopyTo(toCopyTo,5);
            Console.WriteLine("escrivim contingut array");
            foreach (int num in toCopyTo)
            {
                Console.Write(num +" ");
            }
            Console.WriteLine();
            Console.WriteLine("Usos de IList");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Pila a list");
            List<int> pilaList = myPila.ToList();
            Console.WriteLine("Pila 0");
            Console.WriteLine(myPila[0]);
            Console.WriteLine("Llista 0");
            Console.WriteLine(pilaList[0]);
        }
    }
}
