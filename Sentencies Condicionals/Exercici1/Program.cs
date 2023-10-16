namespace Exercici1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int entrada;
            Console.WriteLine("Escriu un enter");
            entrada = Convert.ToInt32(Console.ReadLine());
            if (entrada % 2 == 0) 
            {
                Console.WriteLine("Entrada es parell");
            }
            else
            {
                Console.WriteLine("Entrada es senar");
            }
            if (entrada % 7 == 0)
            {
                Console.WriteLine("Entrada es múltiple de 7");
            }
            else
            {
                Console.WriteLine("Entrada no es múltiple de 7");    
            }
        }
    }
}