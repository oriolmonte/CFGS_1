namespace ex1be
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int entrada = 0;
            int avg = 0; 
            int count = 0;
            int max = int.MinValue;
            int min = int.MaxValue;
            while(entrada != -9999)
            {
                Console.WriteLine("Digue'm un número");
                entrada = Convert.ToInt32(Console.ReadLine());
                if (entrada != -9999)
                {
                    count++;
                    avg += entrada;
                    if (entrada > max)
                    {
                        max = entrada;
                    }
                    if (entrada < min)
                    {
                        min = entrada;
                    }
                }
            }
            avg /= count;
            Console.WriteLine($"Average: {avg} Max: {max} Min: {min}");
        }
    }
}