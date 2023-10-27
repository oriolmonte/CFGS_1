namespace ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input,divisors,total;
            total = 0;
            divisors = 1;
            Console.Write("Entra un enter positiu:");
            input = int.Parse(Console.ReadLine());
            while (total != input && divisors<input) 
            {
                total += divisors;
                divisors++;
            }
            if (total == input)
                Console.WriteLine("Perfecte");
            else
                Console.WriteLine("No perfecte");
        }
    }
}