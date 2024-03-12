namespace ArrayList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaulaLlista<Equip> equips = TaulaLlistaParser("equips.txt");
            Console.WriteLine("Gols Fets");
            PrintPerGolsMarcats(equips);
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Gols Encaixats");
            PrintPerGolsEncaixats(equips);
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Classificacio");
            PrintPerClassificacio(equips);
            Console.WriteLine("-----------------------------------------------------------");
        }
        public static void PrintPerGolsMarcats(TaulaLlista<Equip> equip)
        {
            Equip[] equips = equip.ToArray();
            Array.Sort(equips,new Equip.ComparadorPerGolsMarcats());
            foreach (Equip item in equips)
            {
                Console.WriteLine(item);
            }
        }
        public static void PrintPerClassificacio(TaulaLlista<Equip> equip)
        {
            Equip[] equips = equip.ToArray();
            Array.Sort(equips, new Equip.ComparadorPerClassificacio());
            foreach (Equip item in equips)
            {
                Console.WriteLine(item);
            }
        }
        public static void PrintPerGolsEncaixats(TaulaLlista<Equip> equip)
        {
            Equip[] equips = equip.ToArray();
            Array.Sort(equips, new Equip.ComparadorPerGolsEncaixats());
            foreach (Equip item in equips)
            {
                Console.WriteLine(item);
            }
        }
        public static TaulaLlista<Equip> TaulaLlistaParser (string path)
        {
            TaulaLlista<Equip> resultat = new TaulaLlista<Equip>();
            StreamReader sr = new StreamReader(path);
            string cursor = sr.ReadLine();
            while (cursor != null) 
            {
                string[] cursorA = cursor.Split(';');
                string nom = cursorA[0];
                int punts = int.Parse(cursorA[1]);
                int golsF = int.Parse(cursorA[2]);
                int golsC = int.Parse(cursorA[3]);
                Equip equip = new Equip(nom, golsF, golsC, punts);
                resultat.Afegeix(equip);
                cursor = sr.ReadLine();
            }
            return resultat;
        }

    }
}