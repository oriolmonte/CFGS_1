namespace ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hores = 23;
            int min = 59;
            int seg = 59;
            Console.WriteLine(ConvertToSeconds(hores, seg, min));
            hores = 23;
            min = 58;
            seg = 59;
            Console.WriteLine(ConvertToSeconds(hores, seg, min));
            hores = 23;
            min = 58;
            seg = 58;
            Console.WriteLine(ConvertToSeconds(hores, seg, min));

        }
        public static int ConvertToSeconds(int hores, int segons, int minut) 
        {
            segons += hores * 3600 + minut * 60;
            return segons;
        }
    }
}