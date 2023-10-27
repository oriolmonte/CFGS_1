namespace ex3bé
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int total = 0;
            Console.WriteLine("Input an integer string");
            int input = int.Parse(Console.ReadLine());
            while (input > 0) 
            {
                total += input % 10;
                input /= 10;
            }
            Console.WriteLine(total);
        }
    }
}