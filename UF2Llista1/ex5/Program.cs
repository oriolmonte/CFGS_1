namespace ex5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        public static bool TimeValid(int time)
        {
            bool result = false;
            int hora, min, seg;
            hora = time / 1000;
            min = (time % 1000)/100;
            seg = time %100;
            if (hora <= 23 && min <= 59 && seg <=59)
            {
               result = true;
            }
            else
                result = false;
            return result;
        }
    }
}