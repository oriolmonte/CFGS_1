namespace ex5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char primerChar, segonChar;
            int diff;
            Console.WriteLine("Enter 1st letter");
            primerChar = Console.ReadLine().ToUpper()[0];
            Console.WriteLine("Enter 2nd letter");
            segonChar = Console.ReadLine().ToUpper()[0];
            diff = primerChar - segonChar;
            if (diff < 0)
            {
                diff = -diff;
            }
            for (int i = 1; i <= diff+1; i++) 
            {
                for(int j = 1; j <= diff+1; j++) 
                {
                    if (j == 1)
                        Console.Write($"{i} - {primerChar}");
                    else
                        Console.Write(primerChar);
                }
                primerChar++;
                Console.WriteLine();
            }

        }
    }
}