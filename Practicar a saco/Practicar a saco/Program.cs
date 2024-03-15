namespace Practicar_a_saco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[,] mitjana = AlumnesMitjana("file.txt");
            DisplayMatrix(mitjana);
        
        }
        public static double[,] AlumnesMitjana(string filename)
        {
            string cursor = "a";
            double codi;
            double mitjana;
            StreamReader sr = new StreamReader(filename);
            int size = CountLines(filename);
            double[,] alumnesMatrix = new double[size,2];
            for(int i = 0; i < size; i++) 
            {
                cursor = sr.ReadLine();
                string[] dataLine = cursor.Split(',');
                codi = Convert.ToDouble(dataLine[0]);
                mitjana = (Convert.ToDouble(dataLine[3]) + Convert.ToDouble(dataLine[4]) + Convert.ToDouble(dataLine[5]))/ 3;
                alumnesMatrix[i, 0] = codi;
                alumnesMatrix[i,1] = mitjana;
            }
            return alumnesMatrix;

        }
        public static void DisplayMatrix(double[,] matrix)
        {
            Console.WriteLine("-----------------------------------");
            for(int i = 0; i < matrix.GetLength(0);i++)
            {
                Console.WriteLine($"Codi:{matrix[i, 0]} | Mitjana: {matrix[i, 1]}");
                Console.WriteLine("-----------------------------------");
            }
        }
        public static int CountLines(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            int count = 1;
            string cursor = sr.ReadLine();
            while (cursor != null)
            {
                count++;
                cursor = sr.ReadLine();
            }
            sr.Close();
            return count - 1;
        }
    }
}