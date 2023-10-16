namespace Ex8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int any;
            Console.Write("Any:");
            any = int.Parse(Console.ReadLine());
            if (any % 4 == 0 && (any % 100 != 0 || any % 400 == 0))
            {
                Console.WriteLine(any + " És de traspàs");
            }
            else
            {
                Console.WriteLine(any + " no és de traspàs");
            }
        }
    }
}