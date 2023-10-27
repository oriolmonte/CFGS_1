namespace ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yearCount = 0;
            for (int i = 1000; i <= 10000; i++)
            {
                bool leap = Leap(i);
                if (leap && i%15==0 && i%55==0)
                {
                    Console.WriteLine($"The year {i} fullfills the conditions");
                    yearCount++;
                }
            }
            if (yearCount == 0)
            {
                Console.WriteLine("No year met the conditions");
            }
            else
                Console.WriteLine($"{yearCount} years met the conditions");
        
        }
        static bool Leap(int any)
        {
            if ((any % 4 == 0 && any % 100 != 0) || any % 400 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}