namespace ex9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] chars = { 'A', 'B', 'C','!'};
            for (int i = 0; i < chars.Length; i++)
            {
                Console.WriteLine(ToUppercase(chars[i]));
            }
        }
        public static char ToUppercase(char c)
        {
            int charValue;
            if (c >= 'A' && c <= 'Z')
            {
                charValue = c + 32;
            }
            else
                charValue = '?';
            return(char)charValue;
        }
    }
}