namespace Ex1
{
    internal class Program
    {
        public const string FILENAME = "temperatures.txt";
        static void Main(string[] args)
        {
            int length;
            double temperaturaC, temperaturaF, tempMax=double.MinValue, tempMin=double.MaxValue, tempAvg, tempTotal = 0;
            StreamReader sr = new StreamReader(FILENAME);
            length = Convert.ToInt32(sr.ReadLine());
            Console.WriteLine($"INICIEM LA LECTURA D'UN TOTAL DE {length} TEMPERATURES ");
            if (length>0)
            {
                for (int i = 0; i < length; i++) 
                {
                    temperaturaC = Convert.ToDouble(sr.ReadLine());
                    temperaturaF = Celsius2Fahrenheit(temperaturaC);
                    Console.WriteLine($"LLEGIT -> {temperaturaC} GRAUS CELSIUS, EQUIVALENT A {temperaturaF} Fh");
                    if( temperaturaC > tempMax)
                        tempMax = temperaturaC;
                    if( temperaturaC < tempMin)
                        tempMin = temperaturaC;
                    tempTotal += temperaturaC;                
                }
            }
            sr.Close();
            Console.WriteLine("FI DE LECTURA DE LÍNIES DEL FITXER\n");
            if (length > 0)
            {
                tempAvg = Math.Round(tempTotal / length,2);
                Console.WriteLine($"TEMPERATURA MÀXIMA -->{tempMax} CELSIUS, EQUIVALENT A {Celsius2Fahrenheit(tempMax)} Fh");
                Console.WriteLine($"TEMPERATURA MÍNIMA -->{tempMin} CELSIUS, EQUIVALENT A {Celsius2Fahrenheit(tempMin)} Fh");
                Console.WriteLine($"TEMPERATURA PROMIG -->{tempAvg} CELSIUS, EQUIVALENT A {Celsius2Fahrenheit(tempAvg)} Fh");
            }
            else
                Console.WriteLine("NO HI HA CAP DADA AL FITXER");
        }
        public static double Celsius2Fahrenheit(double grausCelsius)
        {
            double tempF;
            tempF = Math.Round(grausCelsius * 1.8 + 32,2);
            return tempF;
        }
    }
}