using System.Drawing;

namespace Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bubble [500]:");
            BubbleSort(500);
            Console.WriteLine("Insertion[500]:");
            InsertionSort(500);
            Console.WriteLine("Bogo[11]:");
            BogoSort(11);

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
                    nops++;
                }
                aux = numeros[i];
            }
            Console.WriteLine("| " + nops);

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
            int[] arr=GenerateRandomArray(size);
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
            Console.WriteLine("| " + nops);
        }
        public static void InsertionSort(int size)
        {
            int[] arr=GenerateRandomArray(size);
            int n = arr.Length;
            long nops = 0;
            for (int i = 1; i < arr.Length; ++i)
            {
                int aux = arr[i];
                int j = i-1;

                while (j>=0 && arr[j] > aux)
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
            Console.WriteLine("| "+nops);
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