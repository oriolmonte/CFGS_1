namespace ex12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            DateTime ara = DateTime.Now;
            if (ara.DayOfWeek == DayOfWeek.Monday)

                Console.WriteLine("HARD DAY!");

            else if (ara.DayOfWeek >= DayOfWeek.Tuesday && ara.DayOfWeek <= DayOfWeek.Thursday)

                Console.WriteLine("WORKING DAY");

            else if (ara.DayOfWeek == DayOfWeek.Friday)
                Console.WriteLine("TGIF!");
            else
                Console.WriteLine("WEEKEND ☺");

        }
    }
}