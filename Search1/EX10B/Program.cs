namespace EX10B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input, divisors, total;
            total = 0;
            divisors = 1;
            string cursor;
            StreamReader sr = new StreamReader("enters.txt");
            cursor = sr.ReadLine();
            input = int.Parse(cursor);
            while (cursor != null)
            {
                input = int.Parse(cursor);
                while (total != input && divisors < input)
                {
                    total += divisors;
                    divisors++;
                }
                if (total == input)
                    Console.WriteLine($"Perfecte {input}");
                else
                    Console.WriteLine($"No perfecte {input}");
                cursor = sr.ReadLine();
            }
            sr.Close();
        }
    }
}