namespace ex5tots
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int year = 1582;
            while (year<10000)
            {
                bool leap = Leap(year);
                if (leap && year % 15 == 0 && year % 55 == 0)
                {
                Console.WriteLine($"A year exists that meets the conditions {year}");
                }
                year++;
            }
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