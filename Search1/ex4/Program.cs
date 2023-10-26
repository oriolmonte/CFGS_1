namespace ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iter=2;
            Console.WriteLine("Enter positiu:");
            int entrada = int.Parse(Console.ReadLine());
            bool isPrime = true;
            while (iter<entrada && isPrime)
            {
                if (entrada % iter == 0)
                {
                    isPrime = false;
                }
                iter++;
            }
            if (isPrime)
                Console.WriteLine("Es primer.");
            else
                Console.WriteLine("No es primer.");
                
        }
    }
}