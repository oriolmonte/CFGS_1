namespace ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] data = { 1, 2, 3 };
            ResultPrint(data);
        }
        public static void ResultPrint(int[] result)
        {
            Console.Write("{");
            for (int i = 0; i < result.Length; i++)
            {
                if (i == result.Length - 1)
                    Console.Write(result[i]);
                else
                    Console.Write($"{result[i]}, ");
            }
            Console.Write("}\n");
        }
    }
}