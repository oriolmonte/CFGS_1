using System;

namespace ex9
{
    internal class Program
    {
        const float LOOPS1 = 100;
        const float LOOPS2 = 1000;
        const float LOOPS3 = 10000;
        const float LOOPS4 = 100000;

        static void Main(string[] args)
        {
            Random random = new Random();
            int countSim = 0;
            double ratio = 0;
            float countDins = 0;
            float loops = 0;
            while (countSim < 4)
            {
                switch (countSim)
                {
                    case 0:
                        loops = LOOPS1;
                        countDins = Simulació(loops, random);
                        break;
                    case 1:
                        loops = LOOPS2;
                        countDins = Simulació(loops, random); 
                        break;
                    case 2:
                        loops = LOOPS3;
                        countDins = Simulació(loops, random);
                        break;
                    case 3:
                        loops = LOOPS4;
                        countDins = Simulació(loops, random);
                        break;
                }
                ratio = countDins / loops * 4;
                Console.WriteLine($"Resultat Simulació: {ratio} \n\nMarge d'error amb pi: {Math.PI-ratio}\n\n");
                countDins = 0;
                loops = 0;
                countSim++;
            }
        }
        static int Simulació(float loops, Random random)
        {
            int countDins=0;
            int count = 0;
            while (count < loops)
            {
                double x = random.NextDouble();
                double y = random.NextDouble();
                if (Math.Sqrt(x * x + y * y) < 1)
                {
                    countDins++;
                }
                count++;
            }
            return countDins;
        }
    }
}