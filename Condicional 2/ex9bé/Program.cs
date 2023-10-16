namespace ex9bé
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, root, x;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Coeficient a");
            a = double.Parse(Console.ReadLine());
            Console.WriteLine("Coeficient b");
            b = double.Parse(Console.ReadLine());
            Console.WriteLine("Coeficient c");
            c = double.Parse(Console.ReadLine());
            root = (b * b) - (4 * a * c);
            if(a == 0) 
            {
                if (b == 0) 
                {
                    Console.WriteLine("No hi ha equació");
                }
                else 
                {
                    x = -c / b;
                    Console.WriteLine($"Resultat és: {x}");
                }
            }
            else
            {
                if (root > 0) 
                {
                    x = (-b + Math.Sqrt(root)) / 2 * a;
                    Console.Write($"Resultat és: {x}");
                    x = (-b - Math.Sqrt(root)) / 2 * a;
                    Console.Write($" o {x}");
                }
                else if (root < 0)
                {
                    Console.WriteLine("No té solució real");
                    
                    Console.WriteLine($"Resultat és: {-b/2*a}  +/- (\u221A {root})/{2*a}) + i");
                }
                else 
                {
                    x = -b/ (2 * a);
                    Console.WriteLine($"Només una solució: {x}");
                }
            }
        }
    }
}