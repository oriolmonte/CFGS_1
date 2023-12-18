using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;

namespace MenuChachi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo tecla;
            do
            {
                Console.Clear();
                ShowOptions();
                tecla = Console.ReadKey();
                Console.Clear();
                switch(tecla.Key)
                {
                    case ConsoleKey.D1:
                        DoLeap();
                        break;
                    case ConsoleKey.D2:
                        DoOddOrEven();
                        break;
                    case ConsoleKey.D3:
                        //DoTry2ReadValidTimeStamp();
                        Console.WriteLine("Opció 3");
                        MsgNextScreen("prem una tecla per tornar al menu");
                        break;
                    case ConsoleKey.D4:
                        //DoReadAValidTimeStamp();
                        Console.WriteLine("Opció 4");
                        MsgNextScreen("prem una tecla per tornar al menu");
                        break;
                    case ConsoleKey.D5:
                        DoEnterValidDate();
                        break;
                    case ConsoleKey.D6:
                        DoTryReadValidDate();
                        break;
                    case ConsoleKey.D7:
                        DoMCD();
                        break;
                    case ConsoleKey.D0:
                        MsgNextScreen("Press any key to exit");
                        break;
                    default:
                        MsgNextScreen("Error prem una tecla per tornar al menu");
                        break;
                }
            }while(tecla.Key != ConsoleKey.D0);

        }




        #region Menu display functions
        /// <summary>
        /// Mostra un missatge i llegeix una tecla
        /// </summary>
        /// <param name="v">
        /// Missatge a mostrar
        /// </param>
        private static void MsgNextScreen(string v)
        {
            Console.WriteLine(v);
            Console.ReadKey();
        }
        /// <summary>
        /// Mostra les opcions del menu
        /// </summary>
        private static void ShowOptions()
        {
            Console.Clear();
            Console.WriteLine("1)   Leap year?");
            Console.WriteLine("2)   Odd or Even?");
            Console.WriteLine("3)   Try Read Valid Time");
            Console.WriteLine("4)   Read a valid time");
            Console.WriteLine("5)   Read a valid date");
            Console.WriteLine("6)   Try to read a valid date");
            Console.WriteLine("7)   MCD of 2 integers");

            Console.WriteLine("\n\n\nPress 0 to exit.");
        }
        #endregion
        #region Menu Actions 
        /// <summary>
        /// Acció que activa la opció per saber si un numero es parell o imparell
        /// </summary>
        private static void DoOddOrEven()
        {
            try
            {
                Console.Write("ENTRA UN ENTER -->");
                int input = Convert.ToInt32(Console.ReadLine());
                if (input%2==0)
                {
                    Console.WriteLine("EL NOMBRE ES PARELL");
                }
                else
                {
                    Console.WriteLine("EL NOMBRE ES IMPARELL");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                MsgNextScreen("PRESS A KEY TO GO BACK TO MAIN MENU");
            }
        }
        /// <summary>
        /// Acció que activa la opció per que comprovi si les dates que entra l'usuari son vàlides fins que n'introdueixi una
        /// </summary>
        private static void DoEnterValidDate()
        {
            try
            {
                Console.WriteLine(TryReadDate());   
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                MsgNextScreen("PRESS A KEY TO GO BACK TO MAIN MENU");
            }
        }
        /// <summary>
        /// Acció que activa la opció per saber si es un any de traspàs
        /// </summary>
        private static void DoLeap()
        {
            int year;
            Console.Write("ENTER A YEAR --->");
            try
            {
                year = Convert.ToInt32(Console.ReadLine());
                if (IsLeap(year))
                    Console.WriteLine($"{year} IS A LEAP YEAR");
                else
                    Console.WriteLine($"{year} IS NOT A LEAP YEAR");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                MsgNextScreen("PRESS A KEY TO GO BACK TO MAIN MENU");
            }

        }
        /// <summary>
        /// Acció que activa la opció per saber si una data és vàlida
        /// </summary>
        private static void DoTryReadValidDate()
        {
            try
            {
                Console.WriteLine("Entra una data ddmmyyyy");
                int dia, mes, any;
                int date = Convert.ToInt32(Console.ReadLine());
                dia = date / 1000000;
                mes = (date % 1000000) / 10000;
                any = date % 10000;
                if (!DateValid(any, mes, dia)) throw new Exception($"La data {dia:00}/{mes:00}/{any:0000} introduïda no es vàlida");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                MsgNextScreen("PRESS A KEY TO GO BACK TO MAIN MENU");
            }
        }
        /// <summary>
        /// Acció que activa la opció per saber el Minim Comu Divisor de dos nombres enters
        /// </summary>
        private static void DoMCD()
        {
            try
            {
                int big, small, result;
                Console.WriteLine("smaller integer: ");
                big = int.Parse(Console.ReadLine());
                Console.WriteLine("bigger integer: ");
                small = int.Parse(Console.ReadLine());
                result = MinimComuDivisor(big, small);
                Console.WriteLine($"El MCD de {big} i {small} és {result}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                MsgNextScreen("PRESS A KEY TO GO BACK TO MAIN MENU");
            }
        }

        #endregion
        #region Calculation and Data Input
        /// <summary>
        /// Informa la validitat d'una data 
        /// </summary>
        /// <param name="any"></param>
        /// <param name="mes"></param>
        /// <param name="dia"></param>
        /// <returns></returns>
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
            else if (mes < 8 && mes > 0 && mes % 2 != 0)
            {
                result = (any >= 0 && any <= 9999 && dia >= 0 && dia <= 31);
            }
            else if (mes > 7 && mes <= 12 && mes % 2 == 0)
            {
                result = (any >= 0 && any <= 9999 && dia >= 0 && dia <= 31);
            }
            else
            {
                result = (any >= 0 && any <= 9999 && mes >= 0 && mes <= 12 && dia >= 0 && dia <= 30);
            }
            return result;
        }
        /// <summary>
        /// Informa si un any es de traspas
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static bool IsLeap(int year)
        {
            return year % 4 == 0 && year % 100 != 0 || year % 400 == 0;
        }
        /// <summary>
        /// Demana una data fins que tenim una correcta.
        /// </summary>
        /// <returns>
        /// Una string que informa la validitat de la data
        /// </returns>
        public static string TryReadDate()
        {
            Console.WriteLine("Entra una data ddmmyyyy");
            int dia = 0, mes = 0, any = 0;
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
        /// <summary>
        /// Calcula el Minim Comu Divisor de dos enters
        /// </summary>
        /// <param name="bigParam">
        /// Enter Petit</param>
        /// <param name="smallParam">
        /// Enter Gran</param>
        /// <returns>
        /// El resultat del MCD</returns>
        public static int MinimComuDivisor (int bigParam, int smallParam)
        {
            int remainder, small = smallParam, big = bigParam;
            remainder = big % small;
            big = small;
            small = remainder;
            while (remainder > 0)
            {
                remainder = big % small;
                if (remainder != 0)
                {
                    big = small;
                    small = remainder;
                }
            }
            return small;
        }
        #endregion
    }
}