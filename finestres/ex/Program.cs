namespace ex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cursor;
            int primer, actual;
            bool perill = false;
            StreamReader sr = new StreamReader("test.txt");
            cursor = sr.ReadLine();
            if (cursor == null)
                Console.WriteLine("No data");
            else
            {
                primer = int.Parse(cursor);
                cursor = sr.ReadLine();
                while (cursor != null && !perill) 
                {
                    actual = Convert.ToInt32(cursor);
                    if(actual < 10 && primer < 10)
                        perill = true;
                    else
                    {
                        primer = actual;
                        cursor = sr.ReadLine();
                    }
                }
                sr.Close();
                if (perill)
                    Console.WriteLine("En perill d'extinció");
                else
                    Console.WriteLine("Tot bé");
            }
        }
    }
}