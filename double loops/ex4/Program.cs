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
                    if (j != i) Console.Write(j + "+");
                    else Console.Write(j + "=");
                }
                Console.WriteLine(i * (i + 1) / 2);
            }
        }
    }
}
