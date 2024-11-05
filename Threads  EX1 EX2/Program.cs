using System.Diagnostics;
using System.Threading;
using System.Xml.Linq;
namespace Threads
{
internal class Program
{

        static int[,] resultMatrix;
        static int[,] matrixA;
        static int[,] matrixB;

        static void Main(string[] args)
        {
            int threadsLogics = Environment.ProcessorCount;
            int threadsTriats = int.MaxValue;
            Console.WriteLine("Quina mida de matrius vols (n x n)? Introdueix el valor de n: ");
            int n = int.Parse(Console.ReadLine());
            while (threadsTriats != 0) 
            {
                Console.WriteLine($"El processador pot gestionar {threadsLogics} threads simultanis. Quants en vols fer servir?");

                threadsTriats = int.Parse(Console.ReadLine());    
                if (threadsTriats != 0 && threadsTriats<=threadsLogics) {
                    // Crear dues matrius aleatòries de mida n x n una sola vegada
                    matrixA = GenerateRandomMatrix(n, n);
                    matrixB = GenerateRandomMatrix(n, n);
                    resultMatrix = new int[n, n]; // Matriu de resultats buida

                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    // Multiplicar les matrius sense fils
                    MultiplyMatrices(matrixA, matrixB,0,1);

                    stopwatch.Stop();
                    double elapsedMilliseconds = stopwatch.ElapsedTicks * 1000.0 / Stopwatch.Frequency; // Converteix a mil·lisegons

                    Console.WriteLine($"Temps de multiplicació de matrius: {elapsedMilliseconds} ms");

                    // Multiplicar les matrius sense fils
                    Thread[] threads = new Thread[threadsTriats];
                    stopwatch.Restart();
                    for (int i = 0; i < threadsTriats; i++)
                    {
                        threads[i] = new Thread(() => MultiplyMatrices(matrixA, matrixB, i, threadsTriats));
                        threads[i].Start();
                    }
                    for (int i = 0; i < threadsTriats; i++)
                    {
                        threads[i].Join();
                    }
                    double elapsedMilliseconds2 = stopwatch.ElapsedTicks * 1000.0 / Stopwatch.Frequency; // Converteix a mil·lisegons
                    Console.WriteLine($"Temps de multiplicació de matrius amb {threadsTriats} threads: {elapsedMilliseconds2} ms");
                    Console.WriteLine("Vols Imprimir? (Y/N)");
                    string imprimir = Console.ReadLine();
                    if (imprimir=="Y" || imprimir=="y")
                    
                        PrintMatrix(resultMatrix);

                }
            }
        }

        // Funció per generar una matriu aleatòria de m x n
        static int[,] GenerateRandomMatrix(int rows, int cols)
        {
            Random random = new Random();
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = random.Next(1, 100); // Valors aleatoris entre 1 i 9
                }
            }

            return matrix;
        }

        // Funció per multiplicar les matrius sense utilitzar fils
        static void MultiplyMatrices(int[,] matrixA, int[,] matrixB, int current, int threads)
        {
            int rowsA = matrixA.GetLength(0);
            int colsA = matrixA.GetLength(1);
            int colsB = matrixB.GetLength(1);

            int filaInici = current * rowsA / threads;
            int filaFi = Math.Min((current + 1) * rowsA / threads, rowsA);

            for (int i = filaInici; i < filaFi; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < colsA; k++)
                    {
                        sum += matrixA[i, k] * matrixB[k, j];
                    }
                    resultMatrix[i, j] = sum;
                }
            }
        }


        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i<rows; i++)
            {
                for(int j = 0;j < cols; j++)
                {
                    Console.Write($"{matrix[i, j],10}");
                }
                Console.WriteLine();
            }
        }
    }
}

 

