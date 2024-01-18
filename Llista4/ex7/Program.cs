namespace ex7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] input = GeneratePool();
            char[] output = (char[])input.Clone();
            ResultPrint(input);
            ResultPrint(output);
            Console.WriteLine(CheckResults(input, output));
            output[13] = 'A';
            ResultPrint(input);
            ResultPrint(output);
            Console.WriteLine(CheckResults(input, output));
            output[12] = 'A';
            ResultPrint(input);
            ResultPrint(output);
            Console.WriteLine(CheckResults(input, output));
            for (int i = 11; i < output.Length; i++)
            {
                output[i] = 'A';
            }
            ResultPrint(input);
            ResultPrint(output);
            Console.WriteLine(CheckResults(input, output));
            for (int i = 8; i < output.Length; i++)
            {
                output[i] = 'A';
            }
            ResultPrint(input);
            ResultPrint(output);
            Console.WriteLine(CheckResults(input, output));
        }
        public static char[] GeneratePool()
        {
            Random r = new Random();
            char[] pool = new char[14];
            for (int i = 0; i < pool.Length; i++)
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
        public static int CheckResults(char[] target, char[] winning)
        {
            int count = 0;
            for (int i = 0;target.Length > i; i++) 
            {
                if (target[i] == winning[i])
                    count++;
            }
            if (count < 11)
                count = 0;
            return count;
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