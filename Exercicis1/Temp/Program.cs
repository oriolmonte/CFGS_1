namespace Temp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digue'm una temperatura en Celsius: ");
            double temperaturaC = Convert.ToInt32(Console.ReadLine());
            double temperaturaF = (temperaturaC * 1.8) + 32;
            Console.WriteLine("Són " + temperaturaF + " Graus Fahrenheit");
        }
    }
}