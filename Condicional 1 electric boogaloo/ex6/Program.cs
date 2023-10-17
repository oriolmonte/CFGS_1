namespace ex6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Any?");
            int any = Convert.ToInt32(Console.ReadLine());
            if (any > 1701 && any < 2101)
            {
                Console.WriteLine("Any Vàlid");
            }
            else
            {
                Console.WriteLine("Any Invàlid");
            }
        }
    }
}