namespace ex5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num=0;
            Console.WriteLine("Lower limit");
            int lowerLimit = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Upper limit");
            int upperLimit = Convert.ToInt32(Console.ReadLine());
            num = lowerLimit;
            while (num <= upperLimit)
            {
                if (num % 11 != 0)
                {
                    Console.WriteLine($"{num}");
                }
                num++;
            }

        }
    }
}