namespace Ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int[] taula = GenerateRandomTable(500);
            for (int i = 0; i < 5; i++) 
            {
                int rNext=r.Next(0, 101);
                Console.WriteLine(rNext + " " + Search(taula,rNext));
            }
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