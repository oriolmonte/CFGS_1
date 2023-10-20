namespace Exercici2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endevinar1, endevinar2, solucio;
            Random random = new Random();
            solucio = random.Next(1, 11);
            //INTENT 1
            Console.Write("Entra un número de 1 a 10: ");
            endevinar1 = Convert.ToInt32(Console.ReadLine());
            if (endevinar1 == solucio)
            {
                //ENCERTA
                Console.WriteLine("Molt bé, l'has encertat!");
            }
            else//FALLA 1
            {
                Console.WriteLine("Ho sento, no l'has encertat!");
                //INTENT 2
                Console.Write("Entra un número de 1 a 10: ");
                endevinar2 = Convert.ToInt32(Console.ReadLine());
                //FALLA 2
                if (endevinar2 != solucio)
                {
                    Console.WriteLine("Ho sento, no l'has encertat!");
                    Console.WriteLine($"El número a endevinar era el {solucio}");
                }
                else //ENCERTA 2
                    Console.WriteLine("Molt bé, l'has encertat!");
            }

        }
    }
}