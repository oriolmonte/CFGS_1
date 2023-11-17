namespace ex_no_sabia_que_era_un_bucle
{
    internal class Program
    {
        const string INPUT = "test2.txt";
        static void Main(string[] args)
        {
<<<<<<< HEAD
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
=======
            double souBrut = 0, impostos = 0, souNet = 0;
            int rate;
            string cursor;
            double[] brackets = new double[] {12450, 20200, 35200, 60000, 300000};
            double[] ratios = new double[] { 0.19, 0.24, 0.3, 0.37, 0.45, 0.47 };
            rate = GetRate(brackets);
            StreamReader sr = new StreamReader(INPUT);
            cursor = sr.ReadLine();
            while(cursor != null) 
            {
                souBrut += double.Parse(cursor);
                cursor = sr.ReadLine();
            }
            if (rate == 0)
            {
                impostos = souBrut * ratios[rate];
            }
            else
            {
                for (int i = 0; i < rate; i++)
                {
                    impostos += brackets[i] * ratios[i];
                }
                impostos += brackets[rate - 1] * ratios[rate];                
            }
            souNet = souBrut - impostos;
            sr.Close();
            Console.WriteLine(rate);
            Console.WriteLine(impostos);
            Console.WriteLine(souNet);



        }
        static int GetRate(double[] brackets)
        {
            StreamReader sr = new StreamReader(INPUT);
            int rate = 0;
            double cumulative = 0;
            string cursor = sr.ReadLine();
            while(cursor != null && cumulative < brackets[brackets.Length-1]) 
            {
                cumulative += double.Parse(cursor);
                while (cumulative > brackets[rate] && rate < brackets.Length-1)
                {
                    rate += 1;
                }
                cursor = sr.ReadLine(); 
            }
            sr.Close();
            if (cumulative > brackets[brackets.Length - 1])
                return rate+1;
            else 
                return rate;
>>>>>>> 140a767c6e18d239935f42e5d6dc1bcf71470954
        }
    }
}