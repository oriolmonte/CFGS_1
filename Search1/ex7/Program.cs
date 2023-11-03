namespace ex7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cursorInt, currentTotal, position;
            string cursor;
            bool isSum = true;
            StreamReader sr = new StreamReader("enters.txt");
            sr.ReadLine();
            currentTotal = 0;
            cursor = sr.ReadLine();
            while (cursor != null && isSum)
            {
                cursorInt = int.Parse(cursor);
                currentTotal += int.Parse(cursor);
                if (cursorInt != currentTotal)
                {
                    isSum = false;
                }
                currentTotal = 0;
                cursor = sr.ReadLine();
            }
            sr.Close();
            if (isSum)
                Console.WriteLine("Correct");
            else
                Console.WriteLine("Incorrect");
        }
    }
}