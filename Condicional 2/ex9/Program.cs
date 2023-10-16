namespace ex9
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
            if(a == 0 || b == 0 || c == 0)
            {
                if (a == 0 && b!=0 && c!=0)
                {
                    Console.WriteLine("És una equació de 1r grau");
                    x = -c / b;
                    Console.WriteLine("Resultat és: " + x);
                    return;
                }
                else if (a!=0 && b == 0 && c!=0)
                {
                    if (-c < 0 ^ a < 0)
                    {
                        Console.WriteLine("No té solució real");
                        return;
                    }
                    else
                    {
                        x = Math.Sqrt(-c / a); 
                        Console.WriteLine("Resultat és: " + x + " o " + -x);
                        return;
                    }
                }
                else 
                {
                    Console.WriteLine("Invàlid");
                    return;
                }
            }
            if (root < 0) 
            {
                Console.WriteLine("No té solució real");
                x = -b/(2*a);
                double inter = 2 * a;
                Console.WriteLine($"Resultat és: {x}  +/- \u221A ({root}/{inter}) + i" );

            }
            else
            {
                x = (-b + Math.Sqrt(root)) / 2 * a;
                Console.WriteLine("Resultat és: " + x + " o " + -x);
            }
        }
    }
}