namespace Repeteix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Repetiré el que em dius!");
            string text = Console.ReadLine();
            if (text != null)
            {
                Console.WriteLine(text);
                Console.WriteLine("Eh que sóc llest?");
            }
        }
    }
}