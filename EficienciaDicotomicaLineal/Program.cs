namespace EficienciaDicotomicaLineal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Console.WriteLine("Mida;CercaLineal;CercaDicotomica");
            for (int i = 1000;i<=100000;i+=500)
            {
                int numero = r.Next(2,2*i+1);
                int[] array = new int[i];
                for(int j = 1; j<array.Length;j++)
                {
                    array[j] = j*2;
                }
                Console.WriteLine($"{array.Length};{CercaLineal(numero,array)};{CercaDicotomica(numero,array)}");
            }
            
        }

        static int CercaDicotomica(int numero, int[] arr)
        {

        }
        static int CercaLineal(int numeroOperacions, int[] arr) 
        {
        
        }
    }
}
