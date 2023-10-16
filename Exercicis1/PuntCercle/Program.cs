namespace PuntCercle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x, y, r;
            Console.WriteLine("Dona'm un radi");
            r = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Dona'm una coordenada x");
            x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Dona'm una coordenada y");
            y = Convert.ToDouble(Console.ReadLine());
            if (r >= Math.Sqrt(x*x+y*y))
            {
                Console.WriteLine("és a dins");
            }
            else
            {
                Console.WriteLine("és a fora");
            }
        }
    }
}