namespace ex6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int time = 235958;
            if (TimeValid(time)) 
            {
                int timePlusOne = IncreaseSecond(time);
                Console.WriteLine($"{time} +1 second: {timePlusOne}");
            }
            else
            {
                Console.WriteLine("Invalid");
            }
            time = 235959;
            if (TimeValid(time))
            {
                int timePlusOne = IncreaseSecond(time);
                Console.WriteLine($"{time} +1 second: {timePlusOne}");
            }
            else
            {
                Console.WriteLine("Invalid");
            }
            time = 235955;
            if (TimeValid(time))
            {
                int timePlusOne = IncreaseSecond(time);
                Console.WriteLine($"{time} +1 second: {timePlusOne}");
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }
        public static int IncreaseSecond(int value)
        {
            int hora, min, seg;
            hora = value / 10000;
            min = (value % 10000) / 100;
            seg = (value % 100) + 1;
            if (seg == 60)
            {
                seg = 0;
                min++;
                if(min == 60)
                {
                    min = 0;
                    hora++;
                    if (hora == 24)
                    {
                        hora = 0;
                    }
                }
            }
            hora *= 10000;
            min *= 100;
            return hora+min+seg;            
        }
        public static bool TimeValid(int time)
        {
            bool result = false;
            int hora, min, seg;
            hora = time / 10000;
            min = (time % 10000) / 100;
            seg = time % 100;
            if (hora < 24 && min < 60 && seg < 60)
            {
                result = true;
            }
            else
                result = false;
            return result;
        }
    }
}