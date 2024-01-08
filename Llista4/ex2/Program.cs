namespace ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] data = { 0, 0, 0, 0, 0, 4, 5, 5, 5, 5, 5, 5 };
            Console.WriteLine(Hits(data, 0));
            Console.WriteLine(Hits(data, 4));
            Console.WriteLine(Hits(data, 5));
            Console.WriteLine(Hits(data, -1));

        }
        public static int Hits(int[]data, int value)
        {
            int hits = 0;
            for (int i = 0; i < data.Length; i++) 
            {
                if (data[i] == value)
                    hits++;
            }
            return hits;
        }
    }
    
}