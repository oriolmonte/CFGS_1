namespace ex2b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cursorInt, count;
            count = 1;
            string cursor;
            cursor = Console.ReadLine();
            cursorInt = int.Parse(cursor);
            while (cursorInt % 2 != 0 && cursorInt != -9999)
            {
                count++;
                cursor = Console.ReadLine();
                cursorInt = int.Parse(cursor);

            }
            if (cursorInt == -9999)
                Console.WriteLine($"No hi ha parells");
            else
                Console.WriteLine($"{cursorInt} és parell i s'ha trobat a la posició {count}");
        }
    }
}