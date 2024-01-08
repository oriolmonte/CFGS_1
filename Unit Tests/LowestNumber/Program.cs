/*Program by Oriol Monte
 At INS Montilivi*/
namespace LowestNumber
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter 5 integers, comma and space (, ) separated ---> ");
            string integerString = Console.ReadLine();
            //Separating the integer string into an array of strings
            string[] inputIntegersArray = integerString.Split(", ");
            if (inputIntegersArray.Length !=5) 
            {
                Console.WriteLine("Error, size is wrong");
                return;
            }
            int smallestInteger;
            int[] integerArray = new int[inputIntegersArray.Length];
            //filling the integer array with the converted contents from the string
            for(int i  = 0; i < integerArray.Length; i++) 
            {
                integerArray[i] = int.Parse(inputIntegersArray[i]);
            }
            smallestInteger = SmallestInt(integerArray);
            Console.WriteLine(smallestInteger);

        }
        /// <summary>
        /// Gives us the smallest number in a given array of integers
        /// </summary>
        /// <param name="integerArray">
        /// An integer array
        /// </param>
        /// <returns>
        /// The smallest integer in the parameter array
        /// </returns>
        public static int SmallestInt(int[] integerArray) 
        {
            Array.Sort(integerArray);
            return integerArray[0];
        }
    }
}