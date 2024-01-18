namespace ex7nomesenunciat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] seasonResults = GenerateMatrix();
            DoShowResults(seasonResults);
        }
        public static void DoShowResults(int[,] seasonResults)
        {
            Console.WriteLine("The random results are:");
            int[,] matches = seasonResults;
            for (int i = 0; i < matches.GetLength(0); i++)
            {
                char result = GenerateResult(matches[i, 0], matches[i, 1]);
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
                Console.WriteLine($"MATCH # {i + 1} : Local Team : {matches[i, 0]} Visitor Team : {matches[i, 1]} - {winner} ");
            }
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

    }
}