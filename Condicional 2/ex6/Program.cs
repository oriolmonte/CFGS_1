using System.ComponentModel;
using System.Text.Encodings.Web;

namespace Ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Random dau = new Random();
            Console.Write("Introduiu la vostra aposta (€): ");
            double aposta = double.Parse(Console.ReadLine());
            int resultatDau = dau.Next(1, 7);
            int resultatMoneda = dau.Next(0, 2); //creu 0 cara 1
            Console.WriteLine($"Resultat dau: {resultatDau}");
            bool cara = CaraCreu(resultatMoneda);
            if (resultatDau == 6 && !cara)
            {
                Console.WriteLine("Llàstima! Has perdut " + aposta + "€\nTotal: 0");
            }
            else if (resultatDau % 2 == 0 && cara)
            {
                aposta *= 2;
                Console.WriteLine("Has doblat l'aposta!\nTotal:" + aposta + "€");
            }
            else if (resultatDau % 2 == 0 && !cara)
            {
                Console.WriteLine("Torna-ho a intentar, et tornem l'aposta.\nTotal:" + aposta + "€");
            }
            else if (resultatDau % 2 != 0 && cara)
            {
                Console.WriteLine("Torna-ho a intentar, et tornem l'aposta.\nTotal:" + aposta + "€");
            }
            else if (resultatDau % 2 != 0 && !cara)
            {
                aposta *= 0.5;
                Console.WriteLine("Llàstima! Et tornem la meitat.\nTotal:" + aposta + "€");
            }
            else if (resultatDau == 6 && cara)
            {
                aposta *= 10;
                Console.WriteLine("JACKPOT! X10!" + aposta + "€");
            }

        }
        private static bool CaraCreu(int resultatMoneda)
        {
            if (resultatMoneda == 0)
            {
                Console.WriteLine("Creu");
                return false;
            }
            else
                Console.WriteLine("Cara");
                return true;
        }
    }
}