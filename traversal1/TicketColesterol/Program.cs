namespace TicketColesterol
{
    internal class Program
    {
        static void Colesterol(string input)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool colesterol = false;
            string producteColesterol="";
            int quantitat, colesterolCount = 0;
            double preu, total = 0;
            StreamReader sr = new StreamReader(input);
            string cursor = sr.ReadLine();
            while (cursor != null && !colesterol)
            {
                if (cursor.Contains("PIZZ") || cursor.Contains("SAUSAGE"))
                {
                    colesterolCount++;
                    colesterol = colesterolCount >= 2;
                    producteColesterol = $"Conté producte amb colesterol {cursor}\n";
                }
                quantitat = Convert.ToInt32(sr.ReadLine());
                preu = Convert.ToDouble(sr.ReadLine());
                total += quantitat * preu;
                cursor = sr.ReadLine();
            }
            sr.Close();
            if (colesterol)
                Console.WriteLine($"No es pot comprar, massa colesterol");
            else
                Console.WriteLine($"{producteColesterol}Total: {Math.Round(total,2)}€");
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
                Colesterol($"ticket{i + 1}.txt");
        }
    }
}