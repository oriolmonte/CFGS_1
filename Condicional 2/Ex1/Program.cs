using System.ComponentModel;
using System.Text.Encodings.Web;

namespace Ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random dau = new Random();
            Console.OutputEncoding=System.Text.Encoding.UTF8;
            double aposta = double.Parse(Console.ReadLine());
            int resultat = dau.Next(-10,10);
            Console.WriteLine(resultat);
            if (resultat <= 0) 
            {
                Console.WriteLine("Has perdut " + aposta + "€\nTotal: 0");
            }
            else if (resultat>0 && resultat%2 ==0)
            {
                aposta *= 2;
                Console.WriteLine("Has doblat l'aposta!\nTotal:" + aposta + "€");
            }
            else
            {
                Console.WriteLine("Torna-ho a intentar, et tornem l'aposta.\nTotal:" + aposta + "€");
            }
        }
    }
}