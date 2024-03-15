namespace ArrayList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaulaLlista<Equip> equips = TaulaLlistaParser("equips.txt");
            ConsoleKeyInfo tecla;
            do
            {
                Console.Clear();
                ShowOptions();
                tecla = Console.ReadKey();
                Console.Clear();
                switch (tecla.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        PrintAlfabetic(equips);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        PrintPerClassificacio(equips);
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        PrintPerGolsMarcats(equips);
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        PrintPerGolsEncaixats(equips);
                        break;
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        MsgNextScreen("Press any key to exit");
                        break;
                    default:
                        MsgNextScreen("Error prem una tecla per tornar al menu");
                        break;
                }
            } while (tecla.Key != ConsoleKey.D0);
        }
        private static void MsgNextScreen(string v)
        {
            Console.WriteLine(v);
            Console.ReadKey();
        }
        /// <summary>
        /// Mostra les opcions del menu
        /// </summary>
        private static void ShowOptions()
        {
            Console.Clear();
            Console.WriteLine("1)   Llistat Alfabetic");
            Console.WriteLine("2)   Llistat per Classificacio");
            Console.WriteLine("3)   Per Gols Marcats");
            Console.WriteLine("4)   Per gols encaixats");

            Console.WriteLine("\n\n\nPress 0 to exit.");
        }
        public static void PrintPerGolsMarcats(TaulaLlista<Equip> equip)
        {
            Equip[] equips = equip.ToArray();
            Array.Sort(equips,new Equip.ComparadorPerGolsMarcats());
            foreach (Equip item in equips)
            {
                Console.WriteLine(item);
            }
            MsgNextScreen("Prem qualsevol tecla per tornar");
        }
        public static void PrintPerClassificacio(TaulaLlista<Equip> equip)
        {
            Equip[] equips = equip.ToArray();
            Array.Sort(equips, new Equip.ComparadorPerClassificacio());
            foreach (Equip item in equips)
            {
                Console.WriteLine(item);
            }
            MsgNextScreen("Prem qualsevol tecla per tornar");

        }
        public static void PrintPerGolsEncaixats(TaulaLlista<Equip> equip)
        {
            Equip[] equips = equip.ToArray();
            Array.Sort(equips, new Equip.ComparadorPerGolsEncaixats());
            foreach (Equip item in equips)
            {
                Console.WriteLine(item);
            }
            MsgNextScreen("Prem qualsevol tecla per tornar");

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
        public static void PrintAlfabetic(TaulaLlista<Equip> equip)
        {
            equip.Sort();
            for(int i = 0; i<equip.NElems; i++) 
            {
                Console.WriteLine(equip[i]);
            }
            MsgNextScreen("Prem qualsevol tecla per tornar");

        }

    }
}