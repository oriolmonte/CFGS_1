namespace ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int entrada;
            Console.WriteLine("Write an integer");
            entrada = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= entrada; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (j == 1)
                        Console.Write(i);
                    if (j==1 && i==1)
                        Console.Write($" = {i}");
                    else if (j < i)
                        Console.Write($"+{i}");
                    else if (j == i)
                        Console.Write($"+{i} = {i*i}");
                }
                Console.WriteLine();
            }
        }
    }
}