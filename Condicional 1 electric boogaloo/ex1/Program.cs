namespace ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num;
            Console.WriteLine("Dona'm un nombre enter");
            num = Convert.ToInt32(Console.ReadLine());
            if (num%2 == 0 && num != 0)
            {
                Console.WriteLine("Es parell");
            }
            else if (num%7 == 1 && num != 0) 
            {
                Console.WriteLine("Múltiple de 7");
            }
            else
            {
                Console.WriteLine("Número no divisible per 2 o 7");
            }
        }
    }
}