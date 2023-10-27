namespace ex3
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
                    Console.Write(i);                    
                }
                Console.WriteLine();
            }
        }
    }
}