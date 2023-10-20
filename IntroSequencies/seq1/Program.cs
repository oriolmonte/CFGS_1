namespace seq1
{
    internal class Program    {
        const string NOM_FITXER = "nums.txt";
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(NOM_FITXER);

            string linia;

            linia = sr.ReadLine();
            Console.WriteLine(linia);

            linia = sr.ReadLine();
            Console.WriteLine(linia);

            /* afegeix el codi que falta */

            sr.Close();
        }
    }
}