namespace ex13for
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double preu, quant;
            double totalQuant = 0;
            double totalPreu = 0;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            StreamReader sr = new StreamReader("ticket.txt");
            string cursor = sr.ReadLine();
            int elements = int.Parse(cursor);
            for (int i = 0; i < elements; i++)
            {
                sr.ReadLine();
                cursor = sr.ReadLine();
                quant = double.Parse(cursor);
                cursor = sr.ReadLine();
                preu = double.Parse(cursor);
                totalQuant += quant;
                totalPreu += preu * quant;
            }
            sr.Close();
            Console.WriteLine($"FINAL PRICE: {totalPreu} €\nNUMBER OF ITEMS PURCHASED: {totalQuant}");
        }
    }
}