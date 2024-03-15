namespace ex3
{
    internal class Program
    {
        public const string FILENAME = "articles.txt";
        static void Main(string[] args)
        {
            //ASSUMIM FORMAT DADES CORRECTE
            string cursor, name, nameMesCar = "0";
            double preu, preuFinal, preuMesCar = double.MinValue;
            int rateDisc, rateIVA;
            StreamReader sr = new StreamReader (FILENAME);
            cursor = sr.ReadLine ();
            while (cursor != null) 
            {
                name = cursor;
                preu = Convert.ToDouble(sr.ReadLine());
                rateDisc = Convert.ToInt32 (sr.ReadLine());
                rateIVA = Convert.ToInt32 (sr.ReadLine());
                preuFinal = CalculPreuFinal(preu, rateDisc, rateIVA);
                if (preuFinal > preuMesCar) 
                {
                    nameMesCar = name;
                    preuMesCar = preuFinal;
                }
                cursor = sr.ReadLine ();
            }
            sr.Close();
            if (nameMesCar != "0")
            {
                Console.WriteLine($"{nameMesCar} ÉS EL QUE TÉ EL PREU FINAL MÉS CAR = {preuMesCar} euros");
            }
            else
                Console.WriteLine("El fitxer no té dades");

        }
        public static double CalculPreuFinal(double preu, int percDescompte, int percIVA)
        {
            double preuFinal;
            preuFinal = preu - (preu * ((float)percDescompte / 100));
            preuFinal = preuFinal+(preuFinal * ((float)percIVA / 100));
            return Math.Round(preuFinal,2);
        }

    }
}