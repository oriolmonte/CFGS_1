namespace anagram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "anagram";
            string t = "nagaram";
            bool isAnagram = IsAnagram(s, t);
            Console.WriteLine(isAnagram);
        }
        public static bool IsAnagram(string s, string t)
        {
            if (s.Length == t.Length)
            {
                char[] charS = s.ToCharArray();
                char[] charT = t.ToCharArray();
                Array.Sort(charS);
                Array.Sort(charT);            
                Console.WriteLine(t);
            }
            return false;
        }

    }
}