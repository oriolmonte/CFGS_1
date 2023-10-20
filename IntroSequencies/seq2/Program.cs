namespace seq2
{
    internal class Program
    {
        const string NOM_FITXER = "nums2.txt";
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