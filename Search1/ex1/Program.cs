namespace ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int primer, cursorInt, count;
            count = 0;
            string cursor;
            StreamReader sr = new StreamReader("enters.txt");
            primer = int.Parse(sr.ReadLine());
            cursor = sr.ReadLine();
            cursorInt = int.Parse(cursor);
            while (primer != cursorInt && cursor != null)
            {
                count++;
                cursorInt = int.Parse(cursor);
                cursor = sr.ReadLine();
            }
            if (cursor == null)
                Console.WriteLine($"{primer} no s'ha repetit");
            else
                Console.WriteLine($"{primer} s'ha repetit a la posició {count}");
        }
    }
}