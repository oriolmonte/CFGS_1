namespace ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int entrada; 
            Console.WriteLine("Enter an integer between 1 and 100");
            entrada = int.Parse(Console.ReadLine());
            while (entrada<1 || entrada>100)
            {
                Console.WriteLine("Enter an integer between 1 and 100");
                entrada = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Correcte");
        }
    }
}