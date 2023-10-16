using System.Timers;

namespace exercici3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DECLAREM VARIABLES
            int digit1, digit2, digit3, digit4;
            double baseten;
            //OBTENIM INPUT USUARI
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Primer Dígit: ");
            digit1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Segon Dígit: ");
            digit2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Tercer Dígit: ");
            digit3 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Quart Dígit: ");
            digit4 = Convert.ToInt32(Console.ReadLine());
            //OPEREM EL BINARI A BASE 10
            baseten = digit1 * Math.Pow(2, 3) + digit2*Math.Pow(2, 2) + digit3*2+ digit4;
            //OUTPUT
            Console.WriteLine("El número entrat és: " + digit1 + digit2 + digit3 + digit4);
            Console.WriteLine("El resultat és: " + baseten);
        }
    }
}