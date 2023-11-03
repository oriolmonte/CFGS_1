namespace ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int entrada, hores, minuts, segons;
            bool trobat;
            Console.WriteLine("Entra una data en format hhmmss");
            entrada = int.Parse(Console.ReadLine());
            segons = entrada % 100;
            minuts = (entrada / 100) % 100;
            hores = (entrada / 10000) % 100;
            trobat = segons > 59 || minuts > 59 || hores > 23;
            while (trobat)
            {
                Console.WriteLine($"Format Erroni {hores}:{minuts}:{segons}. No és una hora real.\nEntra una data en format hhmmss");
                entrada = int.Parse(Console.ReadLine());
                segons = entrada % 100;
                minuts = (entrada / 100) % 100;
                hores = (entrada / 10000) % 100;
                trobat = segons > 59 || minuts > 59 || hores > 23; 
            }
            Console.WriteLine($"Correcte {hores:00}:{minuts:00}:{segons:00} ");
        }
    }
}