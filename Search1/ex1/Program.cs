namespace ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int primer, cursorInt, count;
            count = 1;
            string cursor;
            StreamReader sr = new StreamReader("enters.txt");
            primer = int.Parse(sr.ReadLine());
            cursor = sr.ReadLine();
            cursorInt = int.Parse(cursor);
            bool trobat = cursorInt == primer;
            while (!trobat && cursor != null)
            {
                count++; 
                cursor = sr.ReadLine();
                cursorInt = int.Parse(cursor);
                trobat = primer == cursorInt;

            }
            if (cursor == null)
                Console.WriteLine($"{primer} no s'ha repetit");
            else
                Console.WriteLine($"{primer} s'ha repetit a la posició {count}");
        }
    }
}