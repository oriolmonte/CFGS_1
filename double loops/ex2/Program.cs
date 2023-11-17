
namespace ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int j = 1; j <= 10; j++)
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine($"{j} x {i} = {j * i}");
                }
                Console.ReadKey();
            }
        }
    }
}