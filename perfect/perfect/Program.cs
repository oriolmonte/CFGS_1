namespace perfect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 28;
            bool perfecte = false;
            int cumul = 0;
            int currentDiv = 1;
            while(currentDiv<n)
            {
                if(n%currentDiv==0)
                    cumul+=currentDiv;
                currentDiv++;
            }
            if (cumul==n)
            {
                perfecte = true;
            }
            Console.WriteLine(perfecte);
        }
    }
}