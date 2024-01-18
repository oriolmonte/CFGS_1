using System.Text;

namespace ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //String a = "aaa<<<<jjjjiia";
            //Console.WriteLine(Ocurrences(a, 'a'));
            //List<int> list = WhereIs(a, 'a');
            //foreach (int i in list)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine(Reverse(a));
            //String b = "racecar";
            //Console.WriteLine(IsPalindrome(b));
            //Console.WriteLine(IsPalindrome("rachas"));
            //Console.WriteLine(IsPalindrome("abba"));
            //Console.WriteLine(IsPalindromeNoBlanks("ab ba"));
            //Console.WriteLine(IsPalindromeNoBlanks("bb ba"));
            ////Console.WriteLine(ToUpperCase("BaBc!AzA<"));
            Console.WriteLine(GreaterThan("salt", "Salt"));
            Console.WriteLine(GreaterThan("b", "aa"));
            Console.WriteLine(GreaterThan("salt", "salt"));
            Console.WriteLine(GreaterThan("sal", "salt"));
            Console.WriteLine(GreaterThan("aa", "bb"));
            Console.WriteLine(GreaterThan("A", "bb"));
            


        }
        public static bool IsNull(String data)
        {
            bool result = false;
            result = (data == null);
            return result;
        }
        public static int Ocurrences(String data, char target) 
        {
            if (IsNull(data)) throw new ArgumentNullException("data");
            int result = 0;
            foreach (char c in data) 
            {
                if (c == target)
                    result++;
            }
            return result;
        }
        public static List<int> WhereIs(String data, char target) 
        {
            if (IsNull(data)) throw new ArgumentNullException("data");
            int count = 0;
            List<int> result = new List<int>();
            foreach (char c in data)
            {
                if (c == target)
                    result.Add(count);
                count++;

            }
            if (result.Count == 0)
                result = null;
            return result;
        }
        public static String Reverse(String data) 
        {
            if (IsNull(data)) throw new ArgumentNullException("data");
            StringBuilder reverse = new StringBuilder();
            for(int i = data.Length-1;i>=0;i--)
            {
                reverse.Append(data[i]);
            }
            return reverse.ToString();
        }
        public static bool IsPalindrome(String data)
        {
            if (IsNull(data)) throw new ArgumentNullException("data");
            bool trobat = false;
            int count = 0;
            char c1, c2;

            while (!trobat && count <= data.Length/2+1)
            {
                c1 = data[count];
                c2 = data[data.Length - 1 - count];
                if (c1 != c2) 
                {
                    trobat = true;
                }
                else 
                {
                    count++; 
                }
            }
            return(!trobat);
        }
        public static bool IsPalindromeNoBlanks(String data)
        {
            if (IsNull(data)) throw new ArgumentNullException("data");
            StringBuilder noBlanks = new StringBuilder();
            foreach (char c in data)
            {
                if (c != ' ')
                {
                    noBlanks.Append(c);
                }
            }
            return(IsPalindrome(noBlanks.ToString()));
        }
        public static string ToUpperCase(String data)
        {
            if (IsNull(data)) throw new ArgumentNullException("data");
            StringBuilder upper = new StringBuilder();
            foreach(char c in data)
            {
                if(c>='a'&&c<='z')
                {
                    upper.Append((char)(c-32));
                }
                else
                    upper.Append(c);
            }
            return upper.ToString();
        }
        public static bool GreaterThan(String first, String second)
        {
            bool result=false;
            bool trobat=false;
            char firstChar, secondChar;
            int count = 0;

            if (IsNull(first)||IsNull(second)) throw new ArgumentNullException("data");
            while(!trobat && count < Math.Min(first.Length, second.Length))
            {
                firstChar = CharToUpper(first[count]);
                secondChar = CharToUpper(second[count]);
                if (firstChar < secondChar) 
                {
                    result = true;
                    trobat = true;
                }
                else if (firstChar > secondChar)
                {
                    trobat = true;
                }
                else
                {
                    count++;
                }
            }
            if (!trobat)
            {
                result=first.Length<second.Length;
            }
            return result;
        }
        public static char CharToUpper(char lower)
        {
            char result;
            if (lower >= 'a' && lower <= 'z')
            {
                result = (char)(lower - 32);
            }
            else
                result = lower;
            return result;
        }
    }
}