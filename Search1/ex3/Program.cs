namespace ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input,divisor,total;
            bool perfect = false;
            total = 0;
            divisor = 1;
            Console.WriteLine("Enter: ");
            input = Convert.ToInt32(Console.ReadLine());
            while (!perfect && total < input)
            {
                total += divisor;
                if(total == input)
                    perfect = true;
                else
                {
                    divisor++;
                    while(input%divisor !=0 && divisor<input)
                    {
                        divisor++;
                    }                    
                }
            }
            if (perfect)
            {
                Console.WriteLine("Perfecte");
            }
            else
                Console.WriteLine("No perfecte");
        }
    }
}