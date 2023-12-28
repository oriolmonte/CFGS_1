namespace ex8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        public static int[,] GenerateMatrix()
        {
            Random random = new Random();
            int[,] matrix = new int[14,2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, 0] = random.Next(10);
                matrix[i, 1] = random.Next(10);
            }
            return matrix;
        }
        public static char[] GeneratePool(int[,] matrix) 
        {
            char[] pool = new char[matrix.GetLength(0)];
            for(int i=0;i<matrix.GetLength(0);i++) 
            {
                pool[i] = GenerateResult(matrix[i, 0], matrix[i,1]);
            }
            return pool;
        }
        public static char GenerateResult(int local, int visitor)
        {
            char result;
            if (local > visitor)
                result = '1';
            else if (local < visitor)
                result = '2';
            else
                result = 'X';
            return result;
        }

    }
}