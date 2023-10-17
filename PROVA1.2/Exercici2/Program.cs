namespace Exercici2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endevinar1, endevinar2, solucio;
            Random random = new Random();
            solucio = random.Next(1,11);
            Console.Write("Entra un número de 1 a 10: ");
            endevinar1 = Convert.ToInt32(Console.ReadLine());
            if( endevinar1 == solucio )
            {
                Console.WriteLine("Molt bé, l'has encertat!");
            }
            else
            {
                Console.WriteLine("Ho sento, no l'has encertat!");
                Console.Write("Entra un número de 1 a 10: ");
                endevinar2 = Convert.ToInt32(Console.ReadLine());
                if ( endevinar2 != solucio )
                {
                    Console.WriteLine("Ho sento, no l'has encertat!");
                    Console.WriteLine($"El número a endevinar era el {solucio}");
                }
            }

        }
    }
}