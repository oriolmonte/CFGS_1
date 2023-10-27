namespace ex5cerca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exists =false;
            int year = 1582;
            while (!exists)
            {
                year++;
                bool leap = Leap(year);
                if (leap && year % 15 == 0 && year % 55 == 0)
                {
                    exists = true;
                }
            }
            if (exists)
                Console.WriteLine($"A year exists that meets the conditions {year}");
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