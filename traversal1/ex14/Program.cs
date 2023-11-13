namespace ex14
{
    internal class Program
    {
        const int POBLACIOPLAGA = 200;
        private const int PLAGASEGMENT = 25;

        static void Main(string[] args)
        {
            int poblacio = 0, cursorInt = 0; 
            bool plaga = false;
            StreamReader sr = new StreamReader("musclos.txt");
            string cursor = sr.ReadLine();
            while (cursor != null && !plaga)
            {
                cursorInt = int.Parse(cursor);
                poblacio += cursorInt;
                if (poblacio>=POBLACIOPLAGA || cursorInt > PLAGASEGMENT)
                    plaga = true;     
                cursor = sr.ReadLine();
            }
            sr.Close();
            if (plaga)
                Console.WriteLine("Tractaments han fallat, hi ha plaga");
            else
                Console.WriteLine("No hi ha plaga");
        }
    }
}