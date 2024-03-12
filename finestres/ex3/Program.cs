namespace ex3
{
    internal class Program
    {
        public const string SOS = "...---...";
        static void Main(string[] args)
        {
            string cursor, primer = "";
            bool perill = false;
            StreamReader sr = new StreamReader("test.txt");
            primer = sr.ReadLine();
            cursor = sr.ReadLine();
            while (cursor != null && !perill) ; 
            {
                if (primer == SOS && cursor == SOS)
                    perill = true ;
                else 
                {
                    primer = cursor;
                    cursor = sr.ReadLine();
                }
            }
            if (perill)
            {
                Console.WriteLine("El vaixell esta en perill");
            }
            else
                Console.WriteLine("No esta en perill");
        }
    }
}