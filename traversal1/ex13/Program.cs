using System.Text.Unicode;

namespace ex13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cursor;
            double preu=0;
            double quant=0;
            double totalQuant = 0;
            double totalPreu = 0;
                      StreamReader sr = new StreamReader("ticket.txt");
            cursor = sr.ReadLine();
            while (cursor != null) 
            {
                for(int i = 0;i<3;i++) 
                {
                    if(i==0)
                        cursor = sr.ReadLine();
                    if (i == 1)
                    {
                        cursor = sr.ReadLine();
                        quant = int.Parse(cursor);
                    }
                    if (i == 2)
                    {
                        cursor = sr.ReadLine();
                        preu = double.Parse(cursor);
                    }
                }
                totalQuant += quant;
                totalPreu += preu;
            }
            sr.Close();
            Console.WriteLine($"FINAL PRICE:{totalPreu} €\n NUMBER OF ITEMS PURCHASED:{totalQuant});
        }
    }
}