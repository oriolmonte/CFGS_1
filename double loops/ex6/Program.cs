namespace ex6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iterations;
            Console.Write("How many times? ");
            iterations = int.Parse(Console.ReadLine());
            while (iterations != 0) 
            {
                for (int i = 0; i < iterations; i++)
                {
                    Console.WriteLine("I shall behave well in class");
                }
                Console.Write("How many times? ");
                iterations = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("END OF PUNISHMENT");
        }
    }
}