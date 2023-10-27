namespace ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int total = 0;
            Console.WriteLine("Input an integer string");
            string input = Console.ReadLine();
            int len = input.Length;
            for (int i = 0; i < len; i++) 
            {
                total += input[i]-48;
            }
            Console.WriteLine(total);
        }
    }
}