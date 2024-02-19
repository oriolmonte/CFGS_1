namespace Greaterthan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String a = "a";
            String b = "aac";
            Console.WriteLine(GreaterThan(a, b));
        }
        public static bool GreaterThan(String first , String second) 
        {
            bool result = false;
            int whosBigger;
            if (first.Length>=second.Length) 
            {
                whosBigger = StringCompare(second, first);
                if (whosBigger == 1)
                    result = true;
                if (whosBigger == 0)
                    result = false;
            }
            else if (second.Length>first.Length) 
            {
                whosBigger = StringCompare(first, second);
                if (whosBigger == 2)
                    result = true;
                if (whosBigger == 0)
                    result = true;
            }
            return result;
        }
        public static int StringCompare(String smaller, String bigger)
        {
            int count = 0;
            int biggerWord = 0;
            bool trobat = false;
            while (!trobat && count < smaller.Length)
            {
                if (smaller[count] == bigger[count])
                    count++;
                else if (smaller[count] > bigger[count])
                {
                    biggerWord = 1;
                    trobat = true;
                }
                else
                {
                    biggerWord = 2;
                    trobat = true;
                }
            }
            return biggerWord;
        }
    }
}