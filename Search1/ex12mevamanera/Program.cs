namespace ex12mevamanera
{
    internal class Program
    {
        const string INPUT = "test.txt";
        static void Main(string[] args)
        {
            double souBrut = 0, impostos = 0, souNet = 0;
            int tram=0;
            string cursor;
            double[] brackets = new double[] { 12450, 20200, 35200, 60000, 300000 };
            double[] preCalculat = new double[] { 2365.5, 4216, 8716, 17892, 117892 };
            double[] ratios = new double[] { 0.19, 0.24, 0.3, 0.37, 0.45, 0.47 };
            StreamReader sr = new StreamReader(INPUT);
            cursor = sr.ReadLine();
            while (cursor != null) 
            {
                souBrut += Convert.ToDouble(cursor);
                cursor = sr.ReadLine();
            }
            while (tram < brackets.Length && souBrut >= brackets[tram])
            {
                impostos = preCalculat[tram];
                tram += 1;
            }
            if (souBrut == brackets[tram - 1])
            {
                tram -= 1;
            }
            else
            {
                impostos += (souBrut - brackets[tram - 1]) * ratios[tram];
            }
            souNet = souBrut - impostos;
            Console.WriteLine($"Sou Brut:{Math.Round(souBrut,2)}\nAquesta persona está en el tram {tram+1}\nAquesta persona ha pagat {impostos} euros en impostos\nEl seu sou net és: {Math.Round(souNet,2)}");
        }
    }
}