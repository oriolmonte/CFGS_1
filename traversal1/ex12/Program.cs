namespace ex12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int prod1, prod2;
            Console.WriteLine("Primer número");
            prod1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Segon número");
            prod2 = int.Parse(Console.ReadLine());
            //sumes de prod1
            Console.Write($"Think about doing {prod1} * {prod2} = ");
            int count = 1;
            while (count <= prod2)
            {
                if (count != prod2)
                    Console.Write($"{prod1}+");
                else
                    Console.Write($"{prod1}\n");
                count++;
            }
            count = 1;
            Console.Write("But it is also equal to ");
            while (count <= prod1)
            {
                if (count != prod1)
                    Console.Write($"{prod2}+");
                else
                    Console.Write($"{prod2}\n");
                count++;
            }
        }
    }
}