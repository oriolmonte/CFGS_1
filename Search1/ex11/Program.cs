namespace ex11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            double countDins = 0;
            double ratioSave, ratio;
            long noop = 100;
            ratioSave = Simulació(random, noop);
            ratio = 0;
            while (ratioSave != ratio)
            {
                ratio = ratioSave;
                noop *= 2;
                ratioSave = Math.Round(Simulació(random, noop),4);
            }
            Console.WriteLine($"Amb el mètode Monte-Carlo hem aproximat pi a: {ratioSave}");
        }
        static double Simulació (Random random, long noops)
        {
            double ratio;
            double countDins = 0;
            for (int j = 1; j <= noops; j++)
            {
                double x = random.NextDouble();
                double y = random.NextDouble();
                if (Math.Sqrt(x * x + y * y) < 1)
                {
                    countDins++;
                }
            }
            ratio = (countDins / noops) * 4;
            return ratio;
        }
    }
}
