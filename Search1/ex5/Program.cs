namespace ex5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cursorInt, count;
            count = 0;
            string cursor;
            StreamReader sr = new StreamReader("cursa.txt");
            cursor = sr.ReadLine();
            cursorInt = int.Parse(cursor);
            while (cursor != null && cursorInt != 231)
            {
                cursorInt = int.Parse(cursor);
                cursor = sr.ReadLine();
                count++;

            }
            if (cursor == null)
            {
                Console.WriteLine("S'ha perdut");
            }
            else
                Console.WriteLine($"Ha arribat en posició: {count+1}");
        }
    }
}