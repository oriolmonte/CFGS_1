namespace Exercici1_Equacio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escriu una equació ax+b=0");
            Console.WriteLine("a");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("b");
            double b = Convert.ToDouble(Console.ReadLine());
            if (a != 0)
            {
                double x = (-b / a);
                Console.WriteLine("x = " + x);
            }
            else
            {
                Console.WriteLine("No te solució, a=0");
            }
        }
    }
}