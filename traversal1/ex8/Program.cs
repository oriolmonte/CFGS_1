namespace ex8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write an integer");
            int entrada = Convert.ToInt32(Console.ReadLine());
            int mult = 1;
            while (mult<=10)
            {
                Console.WriteLine($"{entrada} x {mult} = {entrada*mult}");
                mult++;
            }
        }
    }
}