namespace ex11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, d;
            Console.WriteLine("Escriu una llista de números estrictament ascendent");
            Console.Write("Primer num: ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Segon num: ");
            b = double.Parse(Console.ReadLine());
            while (a>=b)
            {
                Console.Write("Cadena no vàlida, introdueix un número superior: ");
                b = double.Parse(Console.ReadLine());
            }
            Console.Write("Tercer num: ");
            c = double.Parse(Console.ReadLine());
            while (b>=c)
            {
                Console.Write("Cadena no vàlida, introdueix un número superior: ");
                c = double.Parse(Console.ReadLine());
            }
            Console.Write("Quart num: ");
            d = double.Parse(Console.ReadLine());
            while (c>=d)
            {
                Console.Write("Cadena no vàlida, introdueix un número superior: ");
                d= double.Parse(Console.ReadLine());
            }
            Console.WriteLine($"La cadena és {a} {b} {c} {d}");


        }
    }
}