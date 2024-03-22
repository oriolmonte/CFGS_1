namespace CuaEstatica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> prova = new Queue<int>(5);
            prova.Enqueue(1);
            prova.Enqueue(2);
            prova.Enqueue(3);
            prova.Enqueue(4);
            prova.Enqueue(5);
            Queue<int> prova2 = prova.Requeue();
            Console.WriteLine(prova);
            Console.WriteLine(prova2);

            int[] provaAr = prova.ToArray();
            foreach (int i in provaAr)
            {
                Console.WriteLine(i);
            }
            int dequeue = prova.DeQueue();
            
        }
    }
}
