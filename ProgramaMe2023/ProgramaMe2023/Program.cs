namespace ProgramaMe2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader input = new StreamReader("file.txt");
            string cursor = input.ReadLine();
            int entrades = Convert.ToInt32(cursor);
            for (int j = 0; j < entrades; j++)
            {
                char[,] superficie = Superficie(input);
                int g = GranitePoints(superficie);
                Console.WriteLine(g);
                for (int i = 0; i < superficie.GetLength(0); i++)
                {
                    for (int z = 0; z < superficie.GetLength(1); z++)
                    {
                        Console.Write(superficie[i, z]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            input.Close();
        }
        public static char[,] Superficie(StreamReader input)
        {
            string cursor = input.ReadLine();
            int files = Convert.ToInt32(cursor[0]-'0');
            int columnes = Convert.ToInt32(cursor[2]-'0');
            char[,] superficieMatrix = new char[files, columnes];
            for(int i = 0;i<files;i++) 
            {
                cursor = input.ReadLine();
                for (int j = 0;j<columnes;j++)
                {
                    superficieMatrix[i, j] = cursor[j];
                }
            }
            return superficieMatrix;
        }
        public static int GranitePoints(char[,] superficie)
        {
            char[,] superficieCopia = new char[superficie.GetLength(0), superficie.GetLength(1)];
            for (int i = 0; i < superficie.GetLength(0); i++)
            {
                for (int z = 0; z < superficie.GetLength(1); z++)
                {
                    superficieCopia[i, z] = superficie[i, z];
                }
            }
            int granitePoints = 0;
            for(int i = 0;i < superficieCopia.GetLength(0);i++)
            {
                for(int j = 0;j < superficieCopia.GetLength(1);j++)
                {
                    if (superficieCopia[i,j]=='g')
                    {
                        superficieCopia=CheckCluster(superficieCopia, i, j);
                        granitePoints++;
                    }
                }
            }
            return granitePoints;
        }
        public static char[,] CheckCluster(char[,] superficieCopia, int i, int j)
        {
            superficieCopia[i, j] = '-';
            if (i < superficieCopia.GetLength(0) - 1 && superficieCopia[i+1,j]=='g' )
            {
                int iLocal = i + 1;
                int jLocal = j ;
                superficieCopia[iLocal,jLocal] = '-';
                CheckCluster(superficieCopia, iLocal, jLocal);
            }
            if (j < superficieCopia.GetLength(1) - 1 && superficieCopia[i,j+1]=='g')
            {
                int iLocal = i;
                int jLocal = j+1;
                superficieCopia[iLocal, jLocal] = '-';
                CheckCluster(superficieCopia, iLocal, jLocal);
            }
            if (i < superficieCopia.GetLength(0) - 1 && j < superficieCopia.GetLength(1) - 1 && superficieCopia[i+1,j+1]=='g')
            {
                int iLocal = i+1;
                int jLocal = j + 1;
                superficieCopia[iLocal, jLocal] = '-';
                CheckCluster(superficieCopia, iLocal, jLocal);
            }
            if (i < superficieCopia.GetLength(0) - 1 && j !=0 && superficieCopia[i + 1, j - 1] == 'g')
            {
                int iLocal = i + 1;
                int jLocal = j - 1;
                superficieCopia[iLocal, jLocal] = '-';
                CheckCluster(superficieCopia, iLocal, jLocal);
            }

            return superficieCopia;
        }
    }
}