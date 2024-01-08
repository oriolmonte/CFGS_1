/*Program by Oriol Monte
 At INS Montilivi*/

namespace Tire
{
    public class Program
    {
        public const double PI = Math.PI;
        static void Main(string[] args)
        {
            Console.Write("Enter tire radius: ");
            double radius = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(TireLength(radius));
        }
        /// <summary>
        /// This function calculates the length of any circle
        /// </summary>
        /// <param name="radius">
        /// Radius of the circle</param>
        /// <returns>
        /// Length of circle</returns>
        public static double TireLength(double radius)
        {
            return Math.Round(radius*2*PI,2);
        }
    }
}