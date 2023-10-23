namespace ex5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lower limit");
            int lowerLimit = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Upper limit");
            int upperLimit = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ascending (a) or descending? (d)");
            string ascendingDescending = Console.ReadLine().ToLower();
            if(ascendingDescending == "a")
            {
                for (int i = lowerLimit; i <= upperLimit; i++)
                {
                    if (i % 11 != 0)
                    {
                        Console.WriteLine($"{i}");
                    }
                }
            }
            else if(ascendingDescending == "b") 
            {
                for (int i = upperLimit; i >= lowerLimit; i--)
                {
                    if (i % 11 != 0)
                    {
                        Console.WriteLine($"{i}");
                    }
                }
            }

        }
    }
}