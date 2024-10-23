using System.Diagnostics;
using System.Drawing;

namespace Threading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Intentem ordenar un array amb Stupid Sort");
            Console.WriteLine("(Algoritme d'ordenacio terrible (n-1)n! intercanvis de mitjana i (e-1)n! comparacions)");
            Console.WriteLine();
            Console.WriteLine("Introdueix una n (Compte amb numeros superiors a 10, si et passes de 12 pots tardar més de 30 minuts...)");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Stopwatch stopwatch = new Stopwatch();
            int threadsTriats = int.MaxValue;
            int threadsLogics = Environment.ProcessorCount;
            while (threadsTriats != 0)
            {
                Console.WriteLine($"El processador pot gestionar {threadsLogics} threads simultanis. Quants en vols fer servir?");
                threadsTriats = int.Parse(Console.ReadLine());
                if (threadsTriats != 0 && threadsTriats <= threadsLogics)
                {
                    Thread[] threads = new Thread[threadsTriats];
                    Console.WriteLine($"Provem un array 5000 vegades més gran amb bombolla");

                    Console.WriteLine($"BubbleSort[{n*5000}] Multi:");
                    stopwatch.Start();
                    for (int i = 0; i < threadsTriats; i++)
                    {
                        threads[i] = new Thread(() => BubbleSort(n*5000));
                        threads[i].Start();
                    }
                    foreach (Thread thread in threads)
                    {
                        thread.Join();
                    }
                    stopwatch.Stop();
                    double elapsedMilliseconds = stopwatch.ElapsedTicks * 1000.0 / Stopwatch.Frequency; // Converteix a mil·lisegons
                    Console.WriteLine($"BubbleSort[{n * 5000}] amb {threadsTriats} threads:{elapsedMilliseconds} ms");
                    Console.WriteLine($"BubbleSort[{n * 5000}] single:");
                    stopwatch.Restart();
                    BubbleSort(n * 5000);
                    stopwatch.Stop();
                    elapsedMilliseconds = stopwatch.ElapsedTicks * 1000.0 / Stopwatch.Frequency; // Converteix a mil·lisegons
                    Console.WriteLine($" BubbleSort amb un sol thread: {elapsedMilliseconds} ms");
                    Console.WriteLine($"StupidSort[{n}] Multi:");
                    stopwatch.Restart();
                    for (int i = 0; i < threadsTriats; i++)
                    {
                        threads[i] = new Thread(() => BogoSort(n));
                        threads[i].Start();
                    }
                    foreach (Thread thread in threads)
                    {
                        thread.Join();
                    }
                    stopwatch.Stop();
                    elapsedMilliseconds = stopwatch.ElapsedTicks * 1000.0 / Stopwatch.Frequency; // Converteix a mil·lisegons
                    Console.WriteLine($"BogoSort[{n}] amb {threadsTriats} threads:{elapsedMilliseconds} ms");

                    Console.WriteLine($"StupidSort[{n}] Single:");
                    stopwatch.Restart();
                    BogoSort(n);
                    stopwatch.Stop();
                    elapsedMilliseconds = stopwatch.ElapsedTicks * 1000.0 / Stopwatch.Frequency; // Converteix a mil·lisegons
                    Console.WriteLine($"StupidSort amb un sol thread {elapsedMilliseconds} ms");
                }
            }


        }
        public static void BogoSort(int size)
        {
            Random rng = new Random();
            int[] numeros = GenerateRandomArray(size);
            long nops = 0;
            for (int i = 0; i < numeros.Length; i++)
            {
                numeros[i] = rng.Next(0, 1000);
            }
            int aux = 0;
            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i] < aux)
                {
                    Shuffle<int>(rng, numeros);
                    i = 0;
                }
                aux = numeros[i];
            }
        }
        public static void Shuffle<T>(Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }

        public static void BubbleSort(int size)
        {
            int[] arr = GenerateRandomArray(size);
            long nops = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int aux = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = aux;
                        nops++;
                    }
                }
            }
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write(arr[i] + " ");
            //}
        }
        public static void InsertionSort(int size)
        {
            int[] arr = GenerateRandomArray(size);
            int n = arr.Length;
            long nops = 0;
            for (int i = 1; i < arr.Length; ++i)
            {
                int aux = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > aux)
                {
                    arr[j + 1] = arr[j];
                    j--;
                    nops++;
                }
                arr[j + 1] = aux;
                nops++;

            }
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write(arr[i] + " ");
            //}
            Console.WriteLine("| " + nops);
        }



        public static int[] GenerateRandomArray(int size)
        {
            Random rng = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rng.Next(0, 1000);
            }
            return arr;

        }

    }

}