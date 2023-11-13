namespace ex12mevamanera
{
    internal class Program
    {
        const string INPUT = "test.txt";
        static void Main(string[] args)
        {
            double souBrut = 0, impostos = 0, souNet = 0;
            int rate=0;
            string cursor;
            double[] brackets = new double[] { 12450, 20200, 35200, 60000, 300000 };
            double[] calculat = new double[] { 2365.5, 4848, 10560, 22200, 141000 };
            double[] ratios = new double[] { 0.19, 0.24, 0.3, 0.37, 0.45, 0.47 };
            StreamReader sr = new StreamReader(INPUT);
            cursor = sr.ReadLine();
            while (cursor != null) 
            {
                souBrut += Convert.ToDouble(cursor);
                cursor = sr.ReadLine();
            }
            while (rate < brackets.Length && souBrut >= brackets[rate])
            {
                impostos = calculat[rate];
                rate += 1;
            }
            if (souBrut == brackets[rate - 1])
            {
                rate -= 1;
            }
            else
            {
                impostos += (souBrut - brackets[rate - 1]) * ratios[rate];
            }
            souNet = souBrut - impostos;
            Console.WriteLine($"Aquesta persona está en el tram {rate+1}\nAquesta persona ha pagat {impostos} euros en impostos\nEl seu sou net és: {souNet}");
        }
    }
}