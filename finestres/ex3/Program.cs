namespace ex3
{
    internal class Program
    {
        public const string FILENAME = "test.txt";
        public const string SOS = "... --- ...";
        static void Main(string[] args)
        {
            string anterior, actual;
            bool perill = false;
            StreamReader sr = new StreamReader(FILENAME);
            anterior = sr.ReadLine();
            if (anterior == null)
                Console.WriteLine("només una dada");
            else
            {
                actual = sr.ReadLine();

                while (actual != null && !perill)
                {
                    if (anterior == SOS && actual == SOS)
                        perill = true;
                    else
                    {
                        anterior = actual;
                        actual = sr.ReadLine();
                    }
                }
                if (perill)
                    Console.WriteLine("VAIXELL EN PERILL");
                else 
                    Console.WriteLine("TOT BÉ");
            }        
        }
    }
}