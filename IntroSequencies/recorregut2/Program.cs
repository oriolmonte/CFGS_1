namespace recorregut2
{
    internal class Program
    {
        const string NOM_FITXER = "nums4.txt";
        static void Main(string[] args)
        {
            int suma, numLinia;
            int contador;
            string linia;
            StreamReader sr = new StreamReader(NOM_FITXER);

            suma = 0;
            contador = 0;
            linia = sr.ReadLine();

            while (NO_FINAL)
            {
                numLinia = Convert.ToInt32(linia);
                suma = suma + numLinia;
                contador = contador + 1;


                linia = sr.ReadLine();
            }
            Console.WriteLine($"Mitjana: {1.0 * suma / contador}");

            sr.Close();
        }
    }
}

