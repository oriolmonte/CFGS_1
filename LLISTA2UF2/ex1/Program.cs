namespace ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int year = GetLeapYear();
            Console.WriteLine(year);
        }
        public static int GetLeapYear()
        {
            int year = 1;
            while (!IsLeap(year))
            {
                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                    if (!IsLeap(year)) throw new Exception("It's not a leap year");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return year;
        }
        public static bool IsLeap(int year) 
        {
            return year%4==0 && year%100!=0 || year % 400 == 0;
        }
    }
}