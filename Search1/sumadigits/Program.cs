namespace sumadigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int entrada;
            entrada = int.Parse(Console.ReadLine());
            int suma = (entrada*(entrada+1))/2;
            //for(int i = 1; i <= entrada; i++)
            //{
            //    suma += i;
            //}
            Console.WriteLine(suma);
            
        }
    }
}