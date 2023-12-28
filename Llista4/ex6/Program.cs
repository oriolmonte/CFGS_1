namespace ex6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ResultPrint(GeneratePool());
        }
        public static char[] GeneratePool()
        {
            Random r = new Random();
            char[] pool = new char[14];
            for(int i = 0; i < pool.Length; i++) 
            {
                pool[i] = GenerateResult(r.Next(3));
            }
            return pool;
        }
        public static char GenerateResult(int r)
        {
            char result;
            switch (r) 
            {
                case 0:
                    result = '1'; 
                    break;
                case 1:
                    result = 'X';
                    break;
                default:
                    result = '2';
                    break;
            }
            return result;
        }
        public static void ResultPrint(char[] result)
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