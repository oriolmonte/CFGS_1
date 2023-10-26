namespace ex2a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cursorInt, count;
            count = 0;
            string cursor;
            StreamReader sr = new StreamReader("enters.txt");
            cursor = sr.ReadLine();
            cursorInt = int.Parse(cursor);
            while (cursorInt%2!=0 && cursor != null)
            {
                count++;
                cursorInt = int.Parse(cursor);
                cursor = sr.ReadLine();
            }
            if (cursor == null)
                Console.WriteLine($"No hi ha parells");
            else
                Console.WriteLine($"{cursorInt} és parell i s'ha trobat a la posició {count}");
        }
    }
}