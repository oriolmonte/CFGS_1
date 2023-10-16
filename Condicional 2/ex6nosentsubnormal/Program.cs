namespace ex6nosentsubnormal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Random dau = new Random();
            Console.Write("Introduiu la vostra aposta (€): ");
            double aposta = double.Parse(Console.ReadLine());
            double apostaInicial = aposta;
            int resultatDau = dau.Next(1, 7);
            int resultatMoneda = dau.Next(0, 2); //creu 0 cara 1
            Console.WriteLine($"Resultat dau: {resultatDau}");
            bool cara = CaraCreu(resultatMoneda);
            if (cara)
            {
                if (resultatDau == 6) 
                {
                    aposta *= 10;
                    Console.WriteLine($"Jackpot! x10 :{aposta}€");
                }
                else if(resultatDau%2 == 0) 
                {
                    aposta *= 2;
                    Console.WriteLine($"Dobla Aposta: {aposta}€");
                }
                else
                {
                    Console.WriteLine($"Et quedes igual. Total: {aposta}€");
                }
            }
            else
            {
                if (resultatDau == 6) 
                {
                    aposta = 0;
                    Console.WriteLine($"Has perdut tot. Total: {aposta}€");
                
                }
                else if (resultatDau%2!=0)
                {
                    aposta /= 2;
                    Console.WriteLine($"Has perdut la meitat: {aposta}€");
                }
                else
                {
                    Console.WriteLine($"Et quedes igual. Total: {aposta}€");
                }
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