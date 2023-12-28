namespace reverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "the sky is blue";
            Console.WriteLine(ReverseWords(s));
        }
        public static string ReverseWords(string s)
        {
            string[] sArr = s.Split(' ');
            sArr = sArr.Where(val => val != "").ToArray();
            for (int i = 0; i < sArr.Length/2; i++)
            {
                string swap;
                swap = sArr[i];
                sArr[i] = sArr[(sArr.Length - 1) - i];
                sArr[(sArr.Length - 1) - i] = swap;
                
            }
            string solvedStr = String.Join(' ', sArr);
            return solvedStr;
        }

    }
}