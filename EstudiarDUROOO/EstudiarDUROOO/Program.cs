using System.Text;
namespace EstudiarDUROOO

{
    internal class Program
    {
        static void Main(string[] args)
        {

            //int[,] matchesProcessing = MatchesProcessing("1.txt");    
            //Console.WriteLine(MatchResults(matchesProcessing));
            //
            //int x = 5; int y = 4;
            //string[,] matrix = MatrixGet("2.txt", x,y);
            //string[,] transposed = Transpose(matrix);
            //PrintMatrix(matrix);
            //PrintMatrix(transposed);
            //HiddenMessage(MatrixGet("yoda.txt", 3, 3));
            int[] primer = { 1, 2, 3, 4, 5 };
            int[] primer2 = { 1, 90, 3, 4, 5, 199};
            int[] common = CommonElements(primer, primer2);
            foreach (int i in common) 
            {
                Console.WriteLine(i);
            }
        }
        public static int[] Hits(int[] array, int value) 
        {
            List<int> list = new List<int>();
            for (int i = 0; i < array.Length; i++) 
            {
                if (array[i] == value)
                    list.Add(i);
            }
            return list.ToArray();
           
        }
        public static char MatchChar(int visitor, int local)
        {
            char result;
            if (local < visitor)
                result = '1';
            else if (visitor < local)
                result = '2';
            else
                result = 'x';
            return result;
        }
        public static int[,] MatchesProcessing(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            int local, visitor, count=0;
            string line = sr.ReadLine();
            if (line == null) throw new Exception("Empty file");
            
            int length = Convert.ToInt32(line);
            if (length <= 0) throw new Exception("No hi ha dades");
            
            int[,] matches = new int[length,2];
            line = sr.ReadLine();
            while (line != null && count<length) 
            {
                string[] dataLine = line.Split('-');
                local = Convert.ToInt32(dataLine[0]);
                visitor = Convert.ToInt32(dataLine[1]);
                matches[count,0]= local;
                matches[count,1]= visitor;
                line = sr.ReadLine();
                count++;
            }
            return matches;
        }
        public static String MatchResults(int[,] matches)
        {
            int visitor, local;
            char result;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < matches.GetLength(0); i++)
            {
                local = Convert.ToInt32(matches[i,0]);
                visitor = Convert.ToInt32(matches[i, 1]);
                result = MatchChar(local, visitor); 
                sb.Append($"Match {i+1}: {result}\n");
            }
            return sb.ToString();
        }
        public static string[,] MatrixGet(string filename,int x,int y)
        {
            String[,] originalMatrix = new String[x, y];
            StreamReader sr = new StreamReader(filename);
            String cursor = sr.ReadLine();
            for(int i = 0; i < originalMatrix.GetLength(0); i++)
            {
                String[] cursorArr = cursor.Split(',');
                for(int j = 0; j<originalMatrix.GetLength(1); j++)
                {
                    originalMatrix[i,j] = cursorArr[j];
                }
                cursor = sr.ReadLine();
            }

            return originalMatrix;
        }
        public static String[,] Transpose(String[,] matrix) 
        {
            String[,] transposed = new String[matrix.GetLength(1), matrix.GetLength(0)];
            for(int i = 0;i < matrix.GetLength(0);i++)
            {
                for(int j = 0;j < matrix.GetLength(1);j++)
                {
                    transposed[j,i] = matrix[i,j];
                }
            }
            return transposed;
        }
        public static void PrintMatrix(String[,] matrix) 
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == 0)
                        Console.Write("|");
                    Console.Write(matrix[i, j]);
                    if(j == (matrix.GetLength(1) - 1))
                        Console.Write("|");

                }
                Console.WriteLine();
            }
        }
        public static void HiddenMessage(String[,] matrix)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Console.WriteLine("Missatge original:\n");
            for(int i =0; i < matrix.GetLength(0); i++) 
            { 
                for(int j = 0; j < matrix.GetLength(1); j++) 
                {
                    if(j != 0)
                    stringBuilder.Append($" {matrix[i,j]}");
                    else stringBuilder.Append(matrix[i,j]);
                }
                Console.WriteLine(stringBuilder.ToString());
                stringBuilder.Clear();
            }
            Console.WriteLine("\nMissatge Ocult:\n");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j != 0)
                        stringBuilder.Append($" {matrix[j, i]}");
                    else stringBuilder.Append(matrix[j, i]);
                }
                Console.WriteLine(stringBuilder.ToString());
                stringBuilder.Clear();
            }
        }
        public static int[] CommonElements(int[] primer, int[] segon)
        {
            List<int> common = new List<int>();
            int smallerLength = Math.Min(primer.Length, segon.Length);
            int cursorPrimer=0, cursorSegon=0, lastUnique;
            int primerNum, segonNum;
            while (cursorPrimer < smallerLength && cursorSegon < smallerLength)
            {
                primerNum = primer[cursorPrimer];
                segonNum = segon[cursorSegon];
                if (primer.Length >= segon.Length)
                {
                    if (primerNum != segonNum)
                    {
                        common.Add(primerNum);
                        cursorPrimer++;
                        cursorSegon++;
                    }
                    if (primerNum == segonNum)
                    {
                        cursorPrimer++;
                    }
                }
                else
                {
                    if (primerNum != segonNum)
                    {
                        common.Add(segonNum);
                        cursorPrimer++;
                        cursorSegon++;
                    }
                    if (primerNum == segonNum)
                    {
                        cursorSegon++;
                    }
                }
            }
            return common.ToArray();
        }
    }
}