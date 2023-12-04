using System.Data;
using System.Globalization;

namespace ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strArr = { "20/11/2023", "21/11/2023", "22/11/2023", "23/11/2023", "24/11/2023", "25/11/2023", "26/11/2023" };
            DateTime data = new DateTime();
            for (int i = 0; i < strArr.Length; i++) 
            {
                data = DateTime.Parse(strArr[i], CultureInfo.CurrentCulture);
                Console.WriteLine($"Workday? {WorkDay(data.DayOfWeek)}");
            }

        }
        public static bool WorkDay(DayOfWeek day)
        {
            bool result;
            if (day == DayOfWeek.Sunday || day == DayOfWeek.Saturday)
                result = false;
            else
                result = true;
            return result;
        }
    }
}