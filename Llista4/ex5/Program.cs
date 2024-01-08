namespace ex5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GenerateWord());
        }
        public static char[] GenerateWord()
        {
            Random r = new Random();
            char[] result = new char[5];
            for (int i = 0;i<result.Length;i++) 
            {
                result[i] = (char)r.Next(97,122+1);
            }
            return result;
        }

    }

}