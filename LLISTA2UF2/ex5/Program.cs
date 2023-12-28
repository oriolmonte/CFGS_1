using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;

namespace ex5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{ReadDate()}");
        }
        public static string ReadDate()
        {
            Console.WriteLine("Entra una data ddmmyyyy");
            int dia =0, mes = 0, any = 0;
            string output = "";
            bool result = false;
            while (!result)
            {
                try
                {
                    int date = Convert.ToInt32(Console.ReadLine());
                    dia = date / 1000000;
                    mes = (date % 1000000) / 10000;
                    any = date % 10000;
                    if (!DateValid(any, mes, dia)) throw new Exception($"La data {dia:00}/{mes:00}/{any:0000} introduïda no es vàlida");
                    else result = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            output = $"La data {dia:00}/{mes:00}/{any:0000} es vàlida";
            return output;
        }
        public static bool DateValid(int any, int mes, int dia)
        {
            bool result = false;
            
            if (mes == 2)
            {
                if (IsLeap(any))
                    result = (any >= 0 && any <= 9999 && dia >= 0 && dia <= 29);
                else
                    result = (any >= 0 && any <= 9999 && dia >= 0 && dia <= 28);
            }
            else if (mes<8 && mes>0 && mes%2!= 0)
            {
                result = (any >= 0 && any <= 9999 && dia >= 0 && dia <= 31);
            }
            else if (mes>7 && mes<=12 && mes%2 == 0)
            {
                result = (any >= 0 && any <= 9999 && dia >= 0 && dia <= 31);
            }
            else
            {
                result = (any >= 0 && any <= 9999 && mes >= 0 && mes <= 12 && dia >= 0 && dia <= 30);
            }
            return result;
        }
        public static bool IsLeap(int year)
        {
            return year % 4 == 0 && year % 100 != 0 || year % 400 == 0;
        }
    }
}