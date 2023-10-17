namespace ex7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Angle (graus)");
            int angle = Convert.ToInt32(Console.ReadLine());
            if (angle > 360)
            {
                angle %= 360;
            }
            GetQuadrant(angle); 
        }
        public static void GetQuadrant(int angle)
        {
            if (angle >= 0 && angle <= 90)
            {
                Console.WriteLine("Q1");
            }
            else if (angle > 90 && angle <= 180)
            {
                Console.WriteLine("Q2");
            }
            else if (angle > 180 && angle <= 270)
            {
                Console.WriteLine("Q3");
            }
            else
            {
                Console.WriteLine("Q4");
            }
        }
    }
}