using System.Text;

namespace upcMillor

{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lastDigit;
            StreamReader sr = new StreamReader("file.txt");
            int lines = Convert.ToInt32(sr.ReadLine());
            for (int i = 0; i < lines; i++) 
            {
                string final = FinalString(sr.ReadLine());
                Console.WriteLine(final);
            }
        }
        public static string FinalString(string input)
        {
            string result = input;
            int count = 1;
            int lastDigit;
            int sumOdds = 0, sumEven = 0;
            foreach (char c in input)
            {
                if (c != ' ')
                {
                    if (count % 2 != 0)
                    {
                        sumOdds += c-'0'; //WTF char hack
                    }
                    else
                    {
                        sumEven += c-'0';
                    }
                    count++;
                }
            }
            lastDigit = sumOdds * 3 + sumEven;
            if (lastDigit % 10 != 0)
            {
                lastDigit = 10 - (lastDigit % 10);
            }
            return ($"{input} {lastDigit}");
        }
    }
}
