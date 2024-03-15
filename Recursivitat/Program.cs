namespace Recursivitat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(EsTriangular(6));
        }
        public static int Sumatori(int n)
        {
            int resultat = n;
            if (n == 0)
            {
                resultat += 0;
            }
            else
            {
                resultat = Sumatori(n - 1);
                resultat = resultat + n;
            }
            return resultat;
        }
        public static int Producte(int a, int b)
        {
            
            int resultat=0;
            if (a == 0)
            {
                resultat = 0;
            }
            else  
            {
                
                resultat = Producte(a-1, b);
                resultat = resultat + b;
                
            }
            return resultat;
        }

        public static int Potencia(int bas, int exp)
        {
            int resultat = bas;
            if (exp == 0)
            {
                resultat = 1;
            }
            else
            {
                resultat *= bas;
                Potencia(bas, exp-1);
            }
            return bas;
            
        }

        public static long Fibonacci(int posicio)
        {
            long resultat;
            long anterior, anteriorAnterior;
            if(posicio == 1)
            {
                resultat = 1;
            }
            else if(posicio == 2)
            {
                resultat = 1;
            }
            else
            {
                anterior = Fibonacci(posicio - 1);
                anteriorAnterior = Fibonacci(posicio - 2);
                resultat = anterior + anteriorAnterior;
            }
            return resultat;
        }

        public static string binari(int n)
        {
            string resultat = "";
            if (n<2)
            {
                resultat += n % 2;
            }
            else
            {
                resultat += binari(n / 2);
                resultat += n%2;

            }
            return resultat;
        }
        public static long bin(int n) 
        {
            long resultat=0;
            if(n/ 2 == 0)
            {
                resultat += n % 2;
            }
            else
            {
                resultat += bin(n / 2);
                resultat += (n % 2)*10;

            }
            return resultat;

        }

        public static string SwitchBase(int numero, int bas)
        {
            string resultat = "";
            if(numero < bas)
            {
                resultat += numero % bas;
            }
            else
            {
                resultat += SwitchBase(numero / bas, bas);
                resultat += numero % bas;
            }
            return resultat;
        }

        public static int Xifres(int entrada)
        {
            int resultat = 0;
            if (entrada<10)
            {
                resultat += 1;
            }
            else
            {
                resultat += Xifres(entrada / 10);
                resultat += 1;
            }
            return resultat;
        }
        public static bool IsBase (int numero, int bas)
        {
            bool resultat = false;
            if(numero<bas)
            {
                resultat = true;
            }
            else if (numero%10>=bas)
                resultat = false;
            else
            {
                resultat = IsBase(numero / 10, bas);
                resultat = resultat&&numero%10<bas;
            }
            return resultat;
        }
        public static bool EsPrimer(int num)
        {
            if (num == 1) return false;
            else
                return EsPrimer(num, (int)Math.Sqrt(num));
        }
        public static bool EsPrimer (int numero, int divisor)
        {
            bool resultat = false;
            if (divisor == 1)
            {
                resultat = true;
            }
            else if (numero % divisor == 0)
                resultat = false;
            else
            {
                resultat = EsPrimer(numero, divisor - 1);
            }
            return resultat;
        }
        public static bool EsTriangular(int numero)
        {
            return (EsTriangular(numero, 1));
        }
        public static bool EsTriangular(int numero, int acum)
        {
            bool result = true;
            if(numero==0)
            {
                result = true;
            }
            else if(numero<0)
                result= false;
            else
                result = EsTriangular(numero-acum, acum+1);
            return result;


        }
    }
}
