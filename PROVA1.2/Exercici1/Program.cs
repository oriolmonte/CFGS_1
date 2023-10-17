namespace Exercici1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int digit1, digit2, digit3, digit4, suma;
            Random random = new Random();
            //GENEREM NUMERO 1000-9999

            int generat = random.Next(1000,10000);
            Console.WriteLine($"S'ha generat el número: {generat}");
            digit1 = generat % 10;
            digit2 = (generat / 10)%10;
            digit3 = (generat / 100)%10;
            digit4 = (generat / 1000)%10;
            suma = digit1 + digit2 + digit3 + digit4;
            Console.WriteLine($"{digit4} + {digit3} + {digit2} + {digit1} = {suma}");
        }
    }
}