using System.Text.RegularExpressions;

namespace ex8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo tecla;
            do
            {
                Console.Clear();
                ShowOptions();
                tecla = Console.ReadKey();
                Console.Clear();
                switch (tecla.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        DoShowResults();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        DoYourPool();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        DoRandomWin();
                        break;
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        MsgNextScreen("Press any key to exit");
                        break;
                    default:
                        MsgNextScreen("Error prem una tecla per tornar al menu");
                        break;
                }
            } while (tecla.Key != ConsoleKey.D0);
        }
        public static void DoShowResults()
        {
            Console.WriteLine("The random results are:");
            int[,] matches = GenerateMatrix();
            for(int i = 0; i < matches.GetLength(0); i++)
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
                Console.WriteLine($"MATCH # {i+1} : Local Team : {matches[i, 0]} Visitor Team : {matches[i, 1]} - {winner} ");
            }
            MsgNextScreen("Press any key to go to main menu");
        }
        public static void DoRandomWin()
        {
            Console.WriteLine("The results of the random pool are: \n");
            int result;
            int[,] matches = GenerateMatrix();
            char[] winnerPool = GeneratePool(matches);
            int[,] playerMatrix = GenerateMatrix();
            char[] playerPool = GeneratePool(playerMatrix);
            Console.WriteLine("Results are: ");
            ResultPrint(winnerPool);
            Console.WriteLine("Your pool is: ");
            ResultPrint(playerPool);
            result = CheckResults(playerPool, winnerPool);
            Console.WriteLine($"Your prize is: {result}\n\n");
            MsgNextScreen("Press any key to return to main menu.");
        }
        public static void DoYourPool()
        {
            string playerPool;

            string pattern = "[a-zA-VZ3-9]";
            Regex rg = new Regex(pattern);
            Console.WriteLine("Enter your pool (without separators 1 2 or X):\n");
            try
            {
                int[,] winningMatrix = GenerateMatrix();
                char[] winningPool = GeneratePool(winningMatrix);
                playerPool = Console.ReadLine();
                if (rg.IsMatch(playerPool) || playerPool.Length != 14) throw new Exception("Incorrect user input, use 1,X,2 only and 14 characters");
                Console.Clear();
                char[] playerArray = playerPool.ToCharArray();
                Console.WriteLine("Winning pool:");
                ResultPrint(winningPool);
                Console.WriteLine("Your pool:");
                ResultPrint(playerArray);
                Console.WriteLine(CheckResults(winningPool, playerArray));
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                MsgNextScreen("Press any key to return to main menu.");
            }
        }
        #region Generation and Calculation
        /// <summary>
        /// Checks the winnings from two pools
        /// </summary>
        /// <param name="target">Player prediction</param>
        /// <param name="winning">Actual Results</param>
        /// <returns></returns>
        public static int CheckResults(char[] target, char[] winning)
        {
            int count = 0;
            for (int i = 0; target.Length > i; i++)
            {
                if (target[i] == winning[i])
                    count++;
            }
            if (count < 11)
                count = 0;
            return count;
        }
        /// <summary>
        /// Prints a given pool
        /// </summary>
        /// <param name="result">char[] containing a pool</param>
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
        /// <summary>
        /// Randomly generates a matrix with 14 match results
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Turns any match matrix into a pool char[]
        /// </summary>
        /// <param name="matrix">2 dimensional match matrix</param>
        /// <returns></returns>
        public static char[] GeneratePool(int[,] matrix) 
        {
            char[] pool = new char[matrix.GetLength(0)];
            for(int i=0;i<matrix.GetLength(0);i++) 
            {
                pool[i] = GenerateResult(matrix[i, 0], matrix[i,1]);
            }
            return pool;
        }
        /// <summary>
        /// Turns the results of a match inside a matrix into a pool result
        /// </summary>
        /// <param name="local">local team score</param>
        /// <param name="visitor">visitor team score</param>
        /// <returns></returns>
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
        #endregion
        #region MenuDisplayFunctions
        private static void ShowOptions()
        {
            Console.Clear();
            Console.WriteLine("1)   Show match results");
            Console.WriteLine("2)   Did you win?");
            Console.WriteLine("3)   Did random pool win?");

            Console.WriteLine("\n\n\nPress 0 to exit.");
        }
        private static void MsgNextScreen(string v)
        {
            Console.WriteLine(v);
            Console.ReadKey();
        }
        #endregion

    }
}