using System.ComponentModel.DataAnnotations;

namespace endofstring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string hello = "Hello, World!";
            int len = 0;
            int count = 0;
            bool end = false;
            while (!end) 
            {
                if (hello[count+1] != null)
                    count++;
                else
                    end = true;
            }
            Console.WriteLine(count);
        }
    }
}