namespace ex7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            for (int i = 0; i<=300;i+=4)
            {
                Console.WriteLine($"{i}");
                count++;
                if (count==20) 
                {
                    Console.ReadKey();
                    count = 0;
                }
            }
        }
    }
}