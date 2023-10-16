namespace _2n_Grau
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x, a, b, c;
            Console.WriteLine("Dona'm la solució (x) d'una equació de 2n grau de forma ax^2+bx+c=0");
            x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Dona'm a");
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Dona'm b");
            b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Dona'm c");
            c = Convert.ToDouble(Console.ReadLine());
            if (a*x*x+b*x+c == 0)
            {
                Console.WriteLine("a,b i c són vàlides");
            }
            else
            {
                Console.WriteLine("a,b i c NO són vàlides");
            }
        }
    }
}