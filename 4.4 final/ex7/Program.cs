namespace ex7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int entrada;
            Console.WriteLine("Positive integer");
            entrada = int.Parse(Console.ReadLine());
            int iter = 0;
            while (iter < entrada)
            { 
                iter++;
                if (entrada % iter == 0)
                    Console.WriteLine($"{iter} És divisor de {entrada}");
            }
        }
    }
}