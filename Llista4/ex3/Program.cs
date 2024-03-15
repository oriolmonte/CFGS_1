namespace ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] data = { -1, 0, 0, 0, 1, 1, 1, 35, 35 };
            int[] result = HitsIndex(data, 0);
            ResultPrint(result);
            int[] result2 = HitsIndex(data, 4);
            ResultPrint(result2);
            int[] result3 = HitsIndex(data, 1);
            ResultPrint(result3);
            int[] result4 = HitsIndex(data, 35);
            ResultPrint(result4);
        }
        public static int[] HitsIndex(int[] data, int value)
        {
            int[] indexesRaw = new int[data.Length];
            int count = 0;
            for(int i = 0; i < data.Length; i++)
            {
                if (data[i] == value)
                {
                    indexesRaw[count] = i;
                    count++;
                }
            }
            int[] result = new int[count];
            try
            {
                if (count == 0) throw new Exception ("No hits");
                else
                {
                    {
                        for (int j = 0; j < result.Length; j++)
                        {
                            result[j] = indexesRaw[j];
                        }
                    }
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine (e.Message);
                int[] error = { -1};
                return error;
            }
            return result;
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