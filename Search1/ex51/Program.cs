namespace ex51
{
internal class Program
{
        public const string A = "atur.txt";
        static void Main(string[] args)
        {
            int act, ant, mes = 2, a = 1990;
            StreamReader sr = new StreamReader(A);
            string l = sr.ReadLine();
            bool trobat = false;
            if (l != null)
            {
                ant = Convert.ToInt32(l);

                l = canvi(sr, l);
                if (l != null)
                {
                    act = Convert.ToInt32(l);
                    l = canvi(sr, l);
                    if (act > ant)
                    {
                        while (!trobat && l != "0")
                        {
                            act = Convert.ToInt32(l);
                            if (act < ant) trobat = true;
                            else
                            {
                                l = canvi(sr, l);
                                ant = act;
                                mes++;
                                if (mes > 12)
                                {
                                    a++;
                                    mes = 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        while (!trobat && l != "0")
                        {
                            act = Convert.ToInt32(l);
                            if (act > ant) trobat = true;
                            else
                            {
                                l = canvi(sr, l);
                                ant = act;
                                mes++;
                                if (mes > 12)
                                {
                                    a++;
                                    mes = 1;
                                }
                            }
                        }
                    }
                    if (trobat) Console.WriteLine($"La sequencia s'ha invertit a l'any {a} i el mes {mes}");
                    else Console.WriteLine("No s'ha invertit la sequencia");

                }
                else Console.WriteLine("Només hi ha un element");

            }
            else Console.WriteLine("No hi ha elements");
        }

        static string canvi(StreamReader sr, string linia)
        {
            string linia2 = sr.ReadLine();
            while (linia2 == linia)
            {
                linia2 = sr.ReadLine();
            }
            return linia2;
        }
    }
}