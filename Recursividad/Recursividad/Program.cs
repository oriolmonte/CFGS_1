namespace Recursividad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = MCD(150, 39);
            Console.WriteLine(a);
        }

        public static int Potencia(int bas, int exp) 
        {
            if(exp == 0) 
            {
                return 1;
            }
            else
            {
                return bas*Potencia(bas, exp-1);
            }
        }
        public static int WholeDiv(int dividend, int divisor) 
        {
            
            if(divisor==0 || dividend < divisor)
            {
                return 0;
            }
            return 1 + WholeDiv(dividend - divisor, divisor);           
        }
        public static int Remainder(int dividend, int divisor) 
        {
            if(dividend<divisor)
            {
                return dividend;
            }
            return Remainder(dividend-divisor,divisor);

        }
        public static int MCD(int dividend, int divisor) 
        {
            if(dividend%divisor == 0)
            {
                return divisor;
            }
            return MCD(divisor, dividend % divisor);
        }
        public static int Fibonacci(int n)
        {
            int act;
            if (n == 0) act = 0;
            else if (n == 1) act = 1;
            else
            {
                act = Fibonacci(n - 2) + Fibonacci(n - 1);
            }

            return act;
        }
    }
}