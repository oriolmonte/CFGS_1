namespace ex5cerca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exists = false;
            int year = 1582;
            while (!exists)
            {
                bool leap = Leap(year);
                if (leap && year % 15 == 0 && year % 55 == 0)
                {
                    exists = true;
                }
                year++;
            }
            if (exists)
                Console.WriteLine($"A year that meets the conditions exists: {year}");
            else 
                Console.WriteLine("Doesn't exist");
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