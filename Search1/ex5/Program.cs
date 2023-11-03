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
            bool trobat = cursorInt == 231;
            while (cursor != null && !trobat)
            {
                count++;
                cursorInt = int.Parse(cursor);
                trobat = cursorInt == 231;
                cursor = sr.ReadLine();

            }
            if (!trobat)
            {
                Console.WriteLine("S'ha perdut");
            }
            else
                Console.WriteLine($"Ha arribat en posició: {count+1}");
        }
    }
}