namespace ex7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int num = 0;
            while(num <= 300)
            {
                if (num%4 == 0)
                {
                    Console.WriteLine($"{num}");
                    count++;
                }
                if (count == 20)
                {
                    Console.ReadKey();
                    count = 0;
                }
                num++;
            }
        }
    }
}