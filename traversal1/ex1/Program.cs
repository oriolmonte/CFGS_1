namespace ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = getArray();         
            int length = numeros.Length;
            float avg = 0;
            int max = numeros[0]; 
            int min = numeros[0];
            for (int i = 0; i < length; i++) 
            {
                if (numeros[i] > max) 
                {
                    max = numeros[i];
                }
                if (numeros[i] < min) 
                {
                    min = numeros[i]; 
                }
                avg += numeros[i];
            }
            avg /= length;
            Console.WriteLine($"Average: {avg} Max: {max} Min: {min}");
        }
        public static int[] getArray()
        {
            Random dau = new Random();
            int arrSize = dau.Next(2,11);
            int[] arr = new int[arrSize];
            for (int i = 0; i < arrSize; i++) 
            {
                Console.WriteLine("Introdueix un número");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            return arr;            
        }
    }
}