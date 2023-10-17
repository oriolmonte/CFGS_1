namespace ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Velocitat del cotxe");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int vel = Convert.ToInt32(Console.ReadLine());
            if (vel < 80) 
            {
                Console.WriteLine("No hi ha multa");
            }
            else if (vel >= 80 && vel < 100)
            {
                Console.WriteLine("100€ de multa");
            }
            else if (vel>= 100 && vel < 130)
            {
                Console.WriteLine("300€ de multa");
            }
            else 
            {
                Console.WriteLine("600€ de multa i retirada de carnet");
            }
        }
    }
}