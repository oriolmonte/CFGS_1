﻿using System.Text.Unicode;

namespace ex13
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
            //RECORREGUT DE TOTA LA SEQUENCIA 
            while (cursor != null)
            {
                cursor = sr.ReadLine();
                quant = int.Parse(cursor);
                cursor = sr.ReadLine();
                preu = double.Parse(cursor);
                totalQuant += quant;
                totalPreu += preu*quant;
                sr.ReadLine();
            }
            sr.Close();
            Console.WriteLine($"FINAL PRICE: {totalPreu} €\nNUMBER OF ITEMS PURCHASED: {totalQuant}");
        }
    }
}