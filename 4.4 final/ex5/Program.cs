namespace ex5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int small, big, remainder;
            Console.WriteLine("smaller integer: ");
            small = int.Parse(Console.ReadLine());
            Console.WriteLine("bigger integer: ");
            big = int.Parse(Console.ReadLine()); 
            remainder = big % small;
            while (remainder > 0)
            {
                remainder = big % small;
                if (remainder != 0)
                {
                    big = small;
                    small = remainder;
                }              
            }
            Console.WriteLine($"GCD is {small}");
        }
    }
}