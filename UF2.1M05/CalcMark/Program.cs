namespace CalcMark
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your mark");
            int markNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(CalcMark(markNum));
        }
        public static string CalcMark (int num)
        {
            if (num > 8)
                return "A";
            else if (num > 6)
                return "B";
            else if (num > 4)
                return "C";
            else
                return "D";
        }
    }
}