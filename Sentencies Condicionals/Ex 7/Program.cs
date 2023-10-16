namespace Ex_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int angle;
            Console.WriteLine("Introdueix un angle en º");
            angle = int.Parse(Console.ReadLine());
            if (angle <= 0) 
            {
                Console.WriteLine("Només numeros positius");
            }
            else
            {
                //Quadrants
                if (angle > 0 && angle < 90)
                {
                    Console.WriteLine("Q1");
                }
                if (angle > 90 && angle < 180)
                {
                    Console.WriteLine("Q2");
                }
                if (angle > 180 && angle > 270)
                {
                    Console.WriteLine("Q3");
                }
                if (angle > 270 && angle > 360)
                {
                    Console.WriteLine("Q4");
                }
                //EDGE CASES
                if (angle == 90)
                {
                    Console.WriteLine("Angle Recte (Q1~Q2)");
                }
                if (angle == 180)
                {
                    Console.WriteLine("Semicercle (Q2~Q3)");
                }
                if (angle == 270)
                {
                    Console.WriteLine("Q3~Q4)");
                }
                if (angle == 360)
                {
                    Console.WriteLine("Cercle");
                }
            }
        }
    }
}