namespace ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int entrada;
            Console.WriteLine("Write an integer");
            entrada = Convert.ToInt32(Console.ReadLine());
            while (entrada != -9999)
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine($"{entrada} x {i} = {entrada * i}");
                }
                Console.WriteLine("Write an integer");
                entrada = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}