using System.Text.RegularExpressions;

namespace ex8enunciat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The random results are:");
            int[,] matches = GenerateMatrix();
            PrintResult(matches);
        }
        public static int[,] GenerateMatrix()
        {
            Random random = new Random();
            int[,] matrix = new int[14, 2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, 0] = random.Next(10);
                matrix[i, 1] = random.Next(10);
            }
            return matrix;
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
        public static void PrintResult(int[,] results)
        {
            for (int i = 0; i < results.GetLength(0); i++)
            {
                char result = GenerateResult(results[i, 0], results[i, 1]);
                string winner;
                switch (result)
                {
                    case '1':
                        winner = "Local Wins";
                        break;
                    case '2':
                        winner = "Visitor Wins";
                        break;
                    default:
                        winner = "Tie";
                        break;
                }
                Console.WriteLine($"MATCH # {i + 1} : Local Team : {results[i, 0]} Visitor Team : {results[i, 1]} - {winner} ");
            }
        }
    }
}