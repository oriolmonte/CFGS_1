namespace cerca2
{
    internal class Program
    {
        const string NOM_FITXER = "nums6.txt";
        static void Main(string[] args)
        {
            string linia;
            int numLinia, numCercar, pos;
            bool trobat;
            StreamReader sr = new StreamReader(NOM_FITXER);

            numCercar = 9;
            pos = 0;
            trobat = false;
            linia = sr.ReadLine();

            while (!trobat && linia != null)
            {
                numLinia = Convert.ToInt32(linia);
                trobat = (numLinia == numCercar);

                if (!trobat)
                {
                    linia = sr.ReadLine();
                    pos = pos + 1;
                }
            }

            if (trobat)
                Console.WriteLine($"El número {numCercar} està a la posició {pos}");
            else
                Console.WriteLine($"El número {numCercar} no està dins la seqüència");

            sr.Close();
        }
    }
}