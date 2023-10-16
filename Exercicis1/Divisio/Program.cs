namespace Divisio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digue'm un dividend");
            int dividend = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digue-me'n un divisor");
            int divisor = Convert.ToInt32(Console.ReadLine());
            int quocient = dividend / divisor;
            int residu = dividend % divisor;
            Console.WriteLine("El quocient és " + quocient);
            Console.WriteLine("El residu és " +  residu);
        }
    }
}