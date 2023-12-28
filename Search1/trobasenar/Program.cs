namespace trobasenar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] taula = { 2, 4, 4, 6, 12, 13 };
            int posicio;
            posicio = CercaNumSenar(taula);
            if (posicio < 0)
            {
                Console.WriteLine("No n'hi ha");
            }
            else
                Console.WriteLine($"Senar {taula[posicio]} a posició {posicio+1}");
        }

        private static int CercaNumSenar(int[] taula)
        {
            int i = 0;
            bool trobat = false;
            while (i < taula.Length && !trobat)
            {
                if (taula[i] % 2 != 0)
                    trobat = true;
                else
                    i++;
            }
            if (trobat)
                return i;
            else
                return -1;
        }
    }
}