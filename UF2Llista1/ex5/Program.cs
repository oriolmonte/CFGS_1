namespace ex5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] time = { 235959, 245959, 236059, 235960 };
            for(int i = 0; i < time.Length; i++) 
            {
                Console.WriteLine($"{time[i]} valid? {TimeValid(time[i])}");
            }
        
        }
        public static bool TimeValid(int time)
        {
            bool result = false;
            int hora, min, seg;
            hora = time / 10000;
            min = (time % 10000)/100;
            seg = time %100;
            if (hora <= 23 && min <= 59 && seg <= 59)
            {
               result = true;
            }
            else
                result = false;
            return result;
        }
    }
}