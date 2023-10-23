using System;

namespace ex9for
{
    internal class Program
    {
        const double NOOP = 100;
        static void Main(string[] args)
        {
            Random random = new Random();
            double countDins = 0;
            double ratio,noop;
            for (int i = 0; i<=5; i++)
            {
                noop = NOOP * Math.Pow(10, i);
                for (int j = 1; j <= noop; j++)
                {
                    double x = random.NextDouble();
                    double y = random.NextDouble();
                    if (Math.Sqrt(x * x + y * y) < 1)
                    {
                        countDins++;
                    }
                }
                ratio = (countDins / noop) * 4;
                Console.WriteLine($"Resultat Simulació ({noop}): {ratio} \n\nMarge d'error amb pi: {Math.PI - ratio}\n\n");
                countDins = 0;
            }
        }
    }
}