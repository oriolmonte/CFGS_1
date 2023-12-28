namespace Ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] taula = GenerateRandomTable(500);
            Console.WriteLine(Search(taula,3));
            Console.WriteLine(Search(taula, 199));
            Console.WriteLine(Search(taula, 73));
            Console.WriteLine(Search(taula, 51));
            Console.WriteLine(Search(taula, 0));
        }
        public static int[] GenerateRandomTable(int max)
        {
            Random r = new Random();
            int[] data = new int[max];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = r.Next(0, 101);
            }
            return data;
        }
        public static int Search(int[] data, int value) 
        {
            bool trobat = false;
            int i = 0;
            int location = -1;
            while (!trobat && i < data.Length) 
            {
                trobat = data[i] == value;
                if (!trobat)
                {
                    i++;
                }
            }
            if (trobat) location = i;
            return location;
        }
    }

}