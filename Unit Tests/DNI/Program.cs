/*Program by Oriol Monte
 At INS Montilivi*/
namespace DNI
{
    public class Program
    {
        //This string contains all the DNI letters ordered by index (0->T - 22->E) 
        const string LETTERS = "TRWAGMYFPDXBNJZSQVHLCKE";

        static void Main(string[] args)
        {
            int dniNumber; char dniLetter;
            Console.Write("INPUT DNI (8 DIGITS) -->");
            dniNumber = Convert.ToInt32(Console.ReadLine());
            dniLetter = LletraDNI(dniNumber);
            Console.WriteLine(dniLetter);            
            
        }
        /// <summary>
        /// This function uses the modulo operator to get the index of the letter in the DNI number
        /// </summary>
        /// <param name="dniNumber">
        /// 8 Digit integer
        /// </param>
        /// <returns>This function retuns the value of the character at the end of any DNI number</returns>
        public static char  LletraDNI (int dniNumber)
        {
            int indexOfLetter;
            char[] letterArray = LETTERS.ToCharArray();
            indexOfLetter = dniNumber % 23;
            return letterArray[indexOfLetter];
        }
    }
}