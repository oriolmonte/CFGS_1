namespace BestSeller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal sellsMichael, sellsJohn, sellsPeter;
            sellsJohn = Convert.ToDecimal(Console.ReadLine());
            sellsMichael = Convert.ToDecimal(Console.ReadLine());
            sellsPeter = Convert.ToDecimal(Console.ReadLine());
            bool below4;
            if (sellsMichael < 4000 || sellsJohn > 4000 || sellsPeter > 4000)
            {
                below4 = true;
            }
            else
            {
                below4 = false;
            }

                /*a
                 * 
                 */
            if ((sellsMichael>sellsJohn)&&(sellsMichael > sellsPeter)) 
            {
                Console.WriteLine("Michael is best seller");
            }
            if (sellsMichael > 20000 && sellsPeter > 20000 && sellsJohn > 20000)
            {
                Console.WriteLine("No vendor under 20k");
            }
            if(sellsMichael > 5000 || sellsJohn > 5000 || sellsPeter > 5000)
            {
                Console.WriteLine("Some vendor over 5k");
            }
            if((sellsMichael+sellsJohn+sellsPeter)/3 > 8000)
            {
                Console.WriteLine("AVG above 8k");
            }
            if(((sellsMichael + sellsJohn + sellsPeter) * 1 / 3 > 8000) || below4 == true)
            {
                Console.WriteLine("The average of the 3 is over 8.000€ or there is some vendor with sails below 4.000€");
            }
            if (((sellsMichael > sellsJohn) && (sellsMichael > sellsPeter)) || ((sellsJohn > sellsMichael) && (sellsJohn > sellsPeter)))
            {
                Console.WriteLine("Peter isn't best seller");
            }
        }
    }
}