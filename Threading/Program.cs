using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;

namespace Threading
{
    internal class Program
    {
        public static volatile bool isSorted = false;
        static void Main(string[] args)
        {
            Console.WriteLine("Intentem ordenar un array amb Stupid Sort");
            Console.WriteLine("(Algoritme d'ordenacio terrible (n-1)n! intercanvis de mitjana i (e-1)n! comparacions)");
            Console.WriteLine();
            Console.WriteLine("Avisos: Es altament aleatori, tècnicament pot encertarla a la primera!\n" +
                "La meva experiencia es que a partir de 12 es impossible.\n" +
                "No ho fa gaire be per fils, he buscart per internet maneres de fer-ho mes rapid, pero no ho es gaire\n" +
                "Introdueix una mida de l'Array:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Stopwatch stopwatch = new Stopwatch();
            int threadsTriats = int.MaxValue;
            int threadsLogics = Environment.ProcessorCount;
            Console.WriteLine($"El processador pot gestionar {threadsLogics} threads simultanis. Quants en vols fer servir?");
            threadsTriats = int.Parse(Console.ReadLine());
            if (threadsTriats != 0 && threadsTriats <= threadsLogics)
            {
                Thread[] threads = new Thread[threadsTriats];
                Console.WriteLine($"Provem un array 5000 vegades més gran amb bombolla.\n" +
                    $"Encara que el Stupid Sort pot ser molt aleatori al Bubble Sort es pot veure clarament la diferencia\n" +
                    $"Tambe es pot veure com de dolent es en comparacio a un de normal...");

                Console.WriteLine($"BubbleSort[{n*5000}] Multi:");
                stopwatch.Start();
                for (int i = 0; i < threadsTriats; i++)
                {
                    threads[i] = new Thread(() => BubbleSort(n*5000,i,threadsTriats));
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
                BubbleSort(n * 5000, 0, 1);
                elapsedMilliseconds = stopwatch.ElapsedTicks * 1000.0 / Stopwatch.Frequency; // Converteix a mil·lisegons
                Console.WriteLine($"BubbleSort[{n * 5000}] amb un thread:{elapsedMilliseconds} ms");
                stopwatch.Stop();
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
        public static void BogoSort(int size)
        {
            ThreadLocal<Random> rng = new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));
            int[] numeros = GenerateRandomArray(size);
            while (!IsSorted(numeros))
            {
                Shuffle<int>(rng.Value, numeros);
                if (IsSorted(numeros))
                    isSorted = true;

            }
        }
        static bool IsSorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                    return false;   
            }
            return true;
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

        public static void BubbleSort(int size, int current, int total)
        {
            int[] arr = GenerateRandomArray(size);
            int inici = current * arr.Length / total;
            int final = Math.Min((current + 1) * arr.Length / total, arr.Length);

            for (int i = inici; i < final - 1; i++)
            {
                for (int j = inici; j < final - 1 - (i - inici); j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int aux = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = aux;
                    }
                }
            }
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