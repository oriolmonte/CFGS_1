namespace recorregut1
{
    internal class Program
    {
        const string NOM_FITXER = "nums3.txt";
        static void Main(string[] args)
        {
            string linia;
            StreamReader sr = new StreamReader(NOM_FITXER);

            linia = sr.ReadLine();
            
            while (linia!=null)
            {
                Console.Write(linia + " ");


                linia = sr.ReadLine();
            }

            sr.Close();
        }
    }
}