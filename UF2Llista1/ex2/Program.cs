namespace ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("hores: ");
            int hores = Convert.ToInt32(Console.ReadLine());
            Console.Write("minuts: ");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.Write("segons: ");
            int seg = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(ConvertToSeconds(hores, seg, min));
        }
        public static int ConvertToSeconds(int hores, int segons, int minut) 
        {
            segons += hores * 3600 + minut * 60;
            return segons;
        }
    }
}