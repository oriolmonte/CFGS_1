namespace Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digue'm un numero");
            int primerNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digue-me'n un altre");
            int segonNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digue-me'n un altre");
            int tercerNum = Convert.ToInt32(Console.ReadLine());
            //array
            int[] numeros = {primerNum, segonNum, tercerNum};
            Console.WriteLine("Els números son " + numeros[0] + " " + numeros[1] + " " + numeros[2]);
            //invertim
            Array.Reverse(numeros);
            Console.WriteLine("Al revés " + numeros[0] + " " + numeros[1] + " " + numeros[2]);
            //ordenem
            Array.Sort(numeros);
            //sumem
            int suma = primerNum + segonNum + tercerNum;
            Console.WriteLine("De mes petit a mes gran " + numeros[0] + " " + numeros[1] + " " + numeros[2]);
            Console.WriteLine("La suma del números es " + suma);
        }
    }
}