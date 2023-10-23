namespace ex12for
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int prod1, prod2;
            Console.WriteLine("Primer número");
            prod1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Segon número");
            prod2 = int.Parse(Console.ReadLine());
            Console.Write($"Think about doing {prod1} * {prod2} = ");
            for (int i = 1; i < prod2; i++)
            {
                Console.Write($"{prod1}+");
                if (i == prod2-1)
                {
                    Console.Write($"{prod1}\n");
                }
            }
            Console.Write("But it is also equal to ");
            for (int i =1; i < prod1; i++)
            {
                Console.Write($"{prod2}+");
                if (i == prod1-1)
                {
                    Console.Write($"{prod2}");
                }
            }
        }
    }
}