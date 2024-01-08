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
                        DoTry2ReadValidTimeStamp();
                        break;
                    case ConsoleKey.D4:
                        DoReadAValidTimeStamp();
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
                    case ConsoleKey.D8:
                        DoGenerateBulukulu();
                        break;
                    case ConsoleKey.D9:
                        DoSumOfDigits();
                        break;
                    case ConsoleKey.A:
                        DoAverageOfDataFile();
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
            Console.WriteLine("8)   Generate Hulukulu Bulukulu Years");
            Console.WriteLine("9)   Sum of digits");
            Console.WriteLine("A)   Average from file");


            Console.WriteLine("\n\n\nPress 0 to exit.");
        }
        #endregion
        #region Menu Actions 
        /// <summary>
        /// Acció que activa la opció per saber si un numero es parell o imparell
        /// </summary>
        public static void DoOddOrEven()
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
        public static void DoEnterValidDate()
        {
            Console.WriteLine(ReadDate());
            MsgNextScreen("PRESS A KEY TO GO BACK TO MAIN MENU");
        }
        /// <summary>
        /// Acció que activa la opció per saber si es un any de traspàs
        /// </summary>
        public static void DoLeap()
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
        public static void DoTryReadValidDate()
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
        public static void DoMCD()
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
        /// <summary>
        /// Aquesta acció ens dona els anys bulukulu i hulukulu dins un rang
        /// </summary>
        public static void DoGenerateBulukulu()
        {
            try
            {
                Console.WriteLine("Trobem tots els anys Hulukulu i Bulukulu en un rang");
                Console.Write("Entra el llindar inferior: ");
                int anyInferior = Convert.ToInt32(Console.ReadLine());
                Console.Write("Entra el llindar superior: ");
                int anySuperior = Convert.ToInt32(Console.ReadLine());
                for (int i = anyInferior; i <= anySuperior; i++)
                {
                    bool leap = IsLeap(i);
                    if (leap && i % 15 == 0 && i % 55 == 0)
                    {
                        Console.WriteLine($"Year {i} celebrates Hulukulu and Bulukulu festivals");
                    }
                }
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
        /// Action that calculates the sum of digits of any integer
        /// </summary>
        public static void DoSumOfDigits()
        {
            try
            {
                int sum,input;
                Console.WriteLine("Enter an integer");
                input = Convert.ToInt32(Console.ReadLine());
                sum = SumOfDigits(input);
                Console.WriteLine($"Sum of digits --> {sum}");
            }
            catch (Exception e) 
            {
                Console.WriteLine (e.Message);
            }
            finally
            {
                MsgNextScreen("PRESS A KEY TO GO BACK TO MAIN MENU");
            }
        }
        /// <summary>
        /// Asks user for a data file containing an integer per line and calculates the average of the contained integers
        /// </summary>
        public static void DoAverageOfDataFile()
        {
            try
            {
                Console.WriteLine("Enter the filename");
                string filename = Console.ReadLine();
                double avg = AverageFromFile(filename);
                Console.WriteLine($"The average from {filename} is {avg}");
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
        /// Asks user for a timestamp and validates it
        /// </summary>
        public static void DoTry2ReadValidTimeStamp()
        {
            int time;
            int m, h, s, aux;
            Console.Write("ENTER A TIME IN FORMAT hhmmss--->");
            try
            {
                time = Convert.ToInt32(Console.ReadLine());
                s = time % 100;
                aux = time / 100;
                h = aux / 100;
                m = aux % 100;
                if (ValidTime(h, m, s))
                    Console.WriteLine($"{h:00}:{m:00}:{s:00} IS A VALID TIMESTAMP");
                else
                    Console.WriteLine($"{h:00}:{m:00}:{s:00} IS NOT A VALID TIMESTAMP");
            }
            catch  (Exception e ) 
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                MsgNextScreen("PRESS A KEY TO GO BACK TO MAIN MENU");
            }
        }
        /// <summary>
        /// Action that prompts user to enter a timestamp until a valid one is entered
        /// </summary>
        public static void DoReadAValidTimeStamp()
        {
            string time = ReadTime();
            Console.WriteLine($"{time} IS A VALID TIMESTAMP");
            MsgNextScreen("PRESS A KEY TO GO BACK TO MAIN MENU");
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
                    result = (any >= 0 && any <= 9999 && dia > 0 && dia <= 29);
                else
                    result = (any >= 0 && any <= 9999 && dia > 0 && dia <= 28);
            }
            else if (mes < 8 && mes > 0 && mes % 2 != 0)
            {
                result = (any >= 0 && any <= 9999 && dia > 0 && dia <= 31);
            }
            else if (mes > 7 && mes <= 12 && mes % 2 == 0)
            {
                result = (any >= 0 && any <= 9999 && dia > 0 && dia <= 31);
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
        public static string ReadDate()
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
        public static int MinimComuDivisor(int bigParam, int smallParam)
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
        /// <summary>
        /// Caulculates sum of digits
        /// </summary>
        /// <param name="inputParam">Digits to be totaled</param>
        /// <returns>Integer containing sum of digits</returns>
        private static int SumOfDigits(int inputParam)
        {
            int total = 0;
            int input = inputParam;
            while (input > 0)
            {
                total += input % 10;
                input /= 10;
            }
            return total;
        }
        /// <summary>
        /// Calculates the average of a list of integers in a txt file
        /// </summary>
        /// <param name="sr"> file name</param>
        /// <returns>
        /// Average of file</returns>
        public static double AverageFromFile(string sr)
        {
            StreamReader srReader = new StreamReader(sr);
            int contador = 0, total = 0;
            string cursor = srReader.ReadLine();
            while (cursor != null)
            {
                contador++;
                total += int.Parse(cursor);
                cursor = srReader.ReadLine();
            }
            srReader.Close();
            return Math.Round((double)total / contador, 2);
        }
        /// <summary>
        /// Validates a timestamp
        /// </summary>
        /// <param name="h">hours</param>
        /// <param name="m">minutes</param>
        /// <param name="s">seconds</param>
        /// <returns>True if timestamp is valid</returns>
        public static bool ValidTime(int h, int m, int s)
        {
            return h>=0 && h<=23 && m >= 0 && m <= 59 && s>=0 && s<=59;
        }
        /// <summary>
        /// Reads user input until he enters a valid timestamp
        /// </summary>
        /// <returns>
        /// String containing a valid timestamp</returns>
        public static string ReadTime()
        {
            int time = 0;
            int h = 0, m = 0, s = 0;
            int aux;
            bool valid = false;
            while(!valid) 
            {
                try
                {
                    Console.WriteLine("ENTER A TIME IN FORMAT hhmmss -->");
                    time = Convert.ToInt32(Console.ReadLine());
                    s = time % 100;
                    aux = time / 100;
                    h = aux / 100;
                    m = aux % 100;
                    if (!ValidTime(h, m, s)) throw new Exception($"{h:00}:{m:00}:{s:00} is not a valid timestamp");
                    valid = true;
                }
                catch (Exception e) 
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Retry...");
                }
            }
            return ($"{h:00}:{m:00}:{s:00}");

        }
        #endregion

    }
}