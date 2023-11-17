namespace ex_no_sabia_que_era_un_bucle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i<2;i++)
            {
                CalculateTaxes($"test{i}.txt");
            }
        }        
        public static void CalculateTaxes(string test)
        {
            int tram = 0;
            double totalBrut, impostos, totalNet;
            StreamReader sr = new StreamReader(test);
            double[] brackets = new double[] { 12450, 20200, 35200, 60000, 300000 };
            double[] rate = new double[] { 0.19, 0.24, 0.3, 0.37, 0.45, 0.47 };
            double[] calculat = new double[] { 2365.5, 7213.5, 17773.5, 39973.5, 174973.5 };
            totalBrut = GetSouBrut(sr);
            sr.Close();
            impostos = 0;
            while (tram < brackets.Length && totalBrut >= brackets[tram])
            {
                impostos += calculat[tram];
                tram++;
            }
            if (brackets[tram - 1] == totalBrut)
            {
                tram -= 1;
            }
            else
                impostos += (totalBrut - brackets[tram - 1]) * rate[tram];
            totalNet = totalBrut - impostos;
            Console.WriteLine($"Tax Bracket: {tram + 1}\nTaxes: {impostos}\nGross Salary: {totalBrut}\nNet Salary: {totalNet}");
            
        }
        public static double GetSouBrut(StreamReader sr)
        {
            double cursorDouble = 0;
            string cursor;
            cursor = sr.ReadLine();
            while (cursor != null)
            {
                cursorDouble += double.Parse(cursor);
                cursor = sr.ReadLine();
            }
            return cursorDouble;
        }
    }
}