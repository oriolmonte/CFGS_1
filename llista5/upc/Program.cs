using System.Text;

namespace upc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lastDigit;
            StreamReader sr = new StreamReader("file.txt");
            int lines = Convert.ToInt32(sr.ReadLine());
            String cursor;
            for (int i = 0; i < lines; i++)
            {
                cursor = sr.ReadLine();
                string[] cursorSplit = cursor.Split(' ');
                lastDigit = LastDigit(cursorSplit);
                cursor += $" {lastDigit}";
                Console.WriteLine(cursor);
            }

        }
        public static int LastDigit (string[] data)
        {
            int lastDigit;
            int sumOdds=0, sumEven=0;
            for (int i = 0; i<data.Length;i++)
            {
                if((i+1)%2!=0)
                {
                    sumOdds += Convert.ToInt32(data[i]);
                }
                else
                {
                    sumEven += Convert.ToInt32(data[i]);
                }
            }
            lastDigit = sumOdds*3+sumEven;
            if(lastDigit % 10!=0) 
            {
                lastDigit = 10-(lastDigit%10);
            }
            return lastDigit;
        }
    }
}