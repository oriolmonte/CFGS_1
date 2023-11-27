namespace ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RandomDay());
        }
        public static string RandomDay()
        {
            string[] daysOfWeek = { "MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY", "FRIDAY", "SATURDAY", "SUNDAY" };
            Random random = new Random();
            return daysOfWeek[random.Next(0,daysOfWeek.Length)];
        }
    }
}