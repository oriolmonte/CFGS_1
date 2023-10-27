namespace ex10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Escriu número que vols descobrir l'arrel: ");
            int input = int.Parse(Console.ReadLine());
            double xo = input;
            double xi = (xo + (input / xo)) / 2;
            while (xi != xo)
            {
                xo = xi;
                xi = (xo + (input / xo)) / 2;
            }
            Console.WriteLine($"L'arrel de {input} s'aproxima a {xi}");
        }
    }
}