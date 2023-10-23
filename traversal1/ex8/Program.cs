namespace ex8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write an integer");
            int entrada = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i<=10; i++)
            {
                Console.WriteLine($"{entrada} x {i} = {entrada*i}");
            }
        }
    }
}