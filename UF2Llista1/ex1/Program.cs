namespace ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entra un enter: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(ParellSenar(num));
        }
        public static string ParellSenar(int numero)
        {
            if (numero % 2 == 0)
                return ("Parell");
            else
                return ("Senar");
        }
    }
}