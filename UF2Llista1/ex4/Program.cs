using System.Globalization;

namespace ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a date (dd/mm/yyyy): ");
            string dataStr = Console.ReadLine();
            DateTime data = new DateTime();
            data = DateTime.Parse(dataStr,CultureInfo.CurrentCulture);
            Console.WriteLine(WorkDay(data.DayOfWeek));

        }
        public static bool WorkDay(DayOfWeek day)
        {
            bool result;
            if (day == DayOfWeek.Sunday || day == DayOfWeek.Saturday)
                result = true;
            else
                result = false;
            return result;
        }
    }
}