namespace ex6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int any;
            Console.WriteLine("Escriu un any");
            any = int.Parse(Console.ReadLine());
            if (any >= 1701 && any <= 2200)
            {
                if (any < 1801)
                    Console.WriteLine("Segle XVIII");
                else if (any < 1901)
                    Console.WriteLine("Segle XIX");
                else if (any < 2001)
                    Console.WriteLine("Segle XX");
                else if (any < 2101)
                    Console.WriteLine("Segle XXI");
                else 
                    Console.WriteLine("Segle XXII");
            }
            else
            {
                Console.WriteLine("Any invàlid");
            }
        }
    }
}