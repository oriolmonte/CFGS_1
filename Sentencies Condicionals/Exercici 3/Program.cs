namespace Exercici_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int velocitat;
            Console.OutputEncoding=System.Text.Encoding.UTF8;
            Console.WriteLine("Introdueix la velocitat del cotxe (km/h)");
            velocitat = Convert.ToInt32(Console.ReadLine());
            if ( velocitat < 80 ) 
            {
                Console.WriteLine("El cotxe va a una velocitat permesa");
            }
            else
                if (velocitat < 100)
                {
                    Console.WriteLine("100€ de multa");
                }
                else if (velocitat < 130)
                {
                    Console.WriteLine("300€ de multa");
                }
                else if ( velocitat >= 130)
                {
                    Console.WriteLine("600€ de multa i retirada de carnet");
                }
            }
        }
    }
}