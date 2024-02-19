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
            //Console.WriteLine(IsPalindromeNoBlanksBetter("ab ba"));
            //Console.WriteLine(IsPalindromeNoBlanksBetter("bb ba"));
            //Console.WriteLine(ToUpperCase("BaBc!AzA<"));
            Console.WriteLine(GreaterThanPractica("salt", "Salt"));
            Console.WriteLine(GreaterThanPractica("b", "aa"));
            Console.WriteLine(GreaterThanPractica("salt", "salt"));
            Console.WriteLine(GreaterThanPractica("sal", "salt"));
            Console.WriteLine(GreaterThanPractica("aa", "bb"));
            Console.WriteLine(GreaterThanPractica("A", "bb"));
            //int[] nums = { 1, 2, 3, 4, 5 };
            //Console.WriteLine(TaulaToString2(nums));
            //List<string> palis = GetPalindrome("words.txt");
            //for (int i = 0; i < palis.Count; i++)
            //{
            //    Console.WriteLine(palis[i]);
            //}
            //int[] repe = { 1, 1, 1, 1, 1, 12, 2, 2, 2, 2, 3, 4, 5, 6 };
            //List<int> intsRepe = NoRepeats(repe);


            //foreach (int i in intsRepe)
            //{
            //    Console.WriteLine($"{i}");
            //}
            //List<string> alumnes = CodisExcelents("alumnes.txt");
            //foreach(string s in alumnes)
            //{
            //    Console.WriteLine (s);
            //}

        }
        public static bool IsNull(String data)
        {
            return data == null;
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
        public static bool IsPalindromeNoBlanksBetter(String data)
        {
            if (IsNull(data)) throw new ArgumentNullException("data");
            bool trobat = false;
            int i = 0;
            int f = data.Length - 1;
            char c1, c2;

            while (!trobat && i <= f)
            {
                c1 = data[i];
                c2 = data[f];
                if (c1 != c2)
                {
                    trobat = true;
                }
                else if (c1 == ' ') 
                {
                    i++;
                }
                else if(c2 == ' ')
                {
                    f--;
                
                }
                else
                {
                    i++;
                    f--;
                }
            }
            return (!trobat);
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
        public static string TaulaToString(int[] arr)
        {
            string str = "";
            str += "[";
            for (int i = 0; i < arr.Length-1; i++)
            {
                str += $"{arr[i]}, ";
            }
            str += arr[arr.Length-1];
            str += "]";
            return str;
        }
        public static String TaulaToString2(int[] arr)
        {
            StringBuilder sbResult = new StringBuilder();
            sbResult.Append("[");
            for (int i = 0; i < arr.Length - 1; i++)
            {
                sbResult.Append($"{arr[i]}, ");
            }
            sbResult.Append(arr[arr.Length - 1]);
            sbResult.Append("]");
            return sbResult.ToString();
        }
        public static char[] GenerateWord()
        {
            Random r = new Random();
            char[] result = new char[5];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (char)r.Next(97, 122 + 1);
            }
            return result;
        }
        public static List<string> GetPalindrome(string filename)
        {
            List <string> list = new List<string>();  
            StreamReader streamReader = new StreamReader(filename);
            string cursor = streamReader.ReadLine();
            while(cursor != null) 
            {
                if(IsPalindrome(cursor))
                   list.Add(cursor);              
                cursor = streamReader.ReadLine();
            }
            return list;
        }
        public static List<int> NoRepeats(int[] intsRepe)
        {
            List<int> list = new List<int>();
            Array.Sort(intsRepe);
            int anteriorUnic = intsRepe[0];
            list.Add(anteriorUnic);
            int cursor = 0;
            for(int i = 1;i < intsRepe.Length;i++) 
            {
                cursor = intsRepe[i];
                if(cursor != anteriorUnic)
                {
                    list.Add(cursor);
                    anteriorUnic=cursor;
                }
            }
            return list;
        }
        public static List<string> CodisExcelents (string filename) 
        { 
            List<string> alumnes = new List<string>();
            StreamReader streamReader = new StreamReader(filename);
            string cursor = streamReader.ReadLine();
            string[] liniasplit = cursor.Split(',');
            int i = 3;
            bool excelent = true;
            while (cursor != null)
            {
                while (i < liniasplit.Length && excelent)
                {
                    if (Convert.ToInt32(liniasplit[i]) < 8)
                        excelent = false;
                    else
                        i++;
                }
                if (excelent)
                    alumnes.Add(liniasplit[0]);
                excelent = true;
                cursor = streamReader.ReadLine();
                if (cursor!= null)
                    liniasplit = cursor.Split(',');
                i = 3;
            }

            return alumnes;        
        }
        public static bool GreaterThanPractica(string primer, string segon)
        {
            bool trobat = false;
            bool result = false;
            int i = 0;
            char firstChar, secondChar;
            while(!trobat && i<Math.Min(primer.Length, segon.Length))
            {
                firstChar = CharToUpper(primer[i]);
                secondChar = CharToUpper(segon[i]);
                if (firstChar<secondChar)
                {
                    result = true;
                    trobat = true;
                }
                else if (secondChar<firstChar)
                {
                    trobat = true;
                }
                i++;
            }
            if (!trobat)
            {
                result = primer.Length < segon.Length;
            }
            return result;
        }
    }
}