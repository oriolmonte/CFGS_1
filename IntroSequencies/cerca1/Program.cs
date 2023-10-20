namespace cerca1
{
    internal class Program
    {
        const string NOM_FITXER = "nums5.txt";
        static void Main(string[] args)
        {
            string linia;
            int numLinia, numCercar;
            bool trobat;
            StreamReader sr = new StreamReader(NOM_FITXER);

            numCercar = 9;
            trobat = false;
            linia = sr.ReadLine();

            while (!trobat && linia!=null)
            {
                numLinia = Convert.ToInt32(linia);
                trobat = (numLinia == numCercar);

                if (!trobat)
                {
                    linia = sr.ReadLine();
                } 
            }

            if(trobat==true)
                Console.WriteLine($"S'ha trobat el número {numCercar}!");
            else
                Console.WriteLine($"No s'ha trobat el número {numCercar}!");

            sr.Close();
        }
    }
}