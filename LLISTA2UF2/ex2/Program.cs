namespace ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int first, second;
            bool correcte=false;
            int middle=0;
            while (!correcte)
            {
                try
                {
                    Console.Write("Entra llindar inferior: ");
                    first = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Entra llindar superior: ");
                    second = Convert.ToInt32(Console.ReadLine());
                    middle = IsMiddle(first, second);
                    correcte = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine($"The number {middle} is correct");
        }
        public static int IsMiddle(int first, int second)
        { 
            bool result;
            if (first >= second) throw new Exception("first >= second");
            Console.WriteLine($"Entra un numero de {first} a {second}: ");
            int input = Convert.ToInt32(Console.ReadLine());
            result = (input > first && input < second);
            if (!result) throw new Exception("Not middle");
            return input;
        }
    }
}