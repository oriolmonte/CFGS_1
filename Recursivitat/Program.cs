﻿namespace Recursivitat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Ordenat(new int[] {1,2,3,7,4,5,6}));
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
        public static bool EsPerfecte(int numero)
        {
            return (EsPerfecte(numero, numero-1, 0));
        }

        public static bool EsPerfecte(int numero, int divisor, int acum)
        {
            bool result = false;
            if (numero == acum)
            {
                result = true;
            }
            else if (divisor == 0)
                result = false;
            else
            {
                while (numero % divisor != 0 && divisor > 0)
                    divisor--;
                result = EsPerfecte(numero, divisor-1, acum+divisor);
            }

            return result;
            
        }
        public static int Reverse (int numero)
        {
            return Reverse(numero, 0);
        }
        public static int Reverse (int numero, int aux)
        {
            if(numero == 0)
            {
                aux +=0;
            }
            else
            {
                aux=Reverse(numero / 10, numero%10+10*aux);
            }
            return aux;
        }
        public static int Max(int[] vector)
        {
            return Max(vector, 0, 0);
        }
        public static int Max(int[] vector, int max, int index)
        {
            if(index==vector.Length)
            {
                max += 0;
            }
            else
            {
                if (max < vector[index])
                {
                    max = vector[index];
                }
                max = Max(vector, max, index+1);
            }
            return max;
        }
        public static int Escalar(int[] vectorA, int[] vectorB)
        {
            return Escalar(vectorA, vectorB, 0, 0);
        }
        public static int Escalar(int[] vectorA, int[] vectorB, int index, int producte)
        {
            
            if (index == vectorA.Length)
            {
                 producte += 0;
            }
            else
            {
                producte += Escalar(vectorA, vectorB, index + 1, vectorA[index] * vectorB[index]);
            }
            return producte;
        }
        public static int IndexOf(int[] vectorA, int busca)
        {
            return IndexOf(vectorA, busca, 0);
        }
        public static int IndexOf(int[] vectorA, int busca, int index)
        {
            int resultat = -1;
            if (vectorA[index]==busca)
            {
                resultat = index;
            }
            else
            {
                resultat = IndexOf(vectorA, busca, index+1);
            }
            return resultat;
        }
        public static bool SumaPrecedents(int[] vectorA)
        {
            return SumaPrecedents(vectorA, 0, 0);
        }
        public static bool SumaPrecedents(int[] vectorA, int index, int acum)
        {
            bool resultat;
            if (index == vectorA.Length)
            {
                resultat = false;
            }
            else if (acum == vectorA[index])
            {
                resultat = true;
            }
            else
            {
                resultat=SumaPrecedents(vectorA, index+1, acum+vectorA[index]);
            }
            return resultat;
        }
        public static bool Capicua(int[] vectorA)
        {
            return Capicua(vectorA, 0, vectorA[0], vectorA[vectorA.Length-1]);
        }
        public static bool Capicua(int[] vectorA, int index, int principi, int final)
        {
            bool resultat = true;
            if(index > vectorA.Length/2)
            {
                resultat = true;
            }
            else if (principi != final)
            {
                resultat = false;
            }
            else
            {
                resultat = Capicua(vectorA, index+1, vectorA[index], vectorA[vectorA.Length-1-index]);
            }
            return resultat;
        }
        public static bool Ordenat(int[] vectorA)
        {
            return Ordenat(vectorA, true, 0,0,false);
        }
        public static bool Ordenat(int[] vectorA, bool reves)
        {
            return Ordenat(vectorA, true, 0, 0, reves);
        }
        public static bool Ordenat(int[] vectorA, bool creixent, int anterior, int index, bool reves)
        {
            bool result = false;    
            if(index == vectorA.Length && creixent) 
            {
                result = true;
            }
            else if(!creixent && !reves)
            {
                Array.Reverse(vectorA);
                result = Ordenat(vectorA, true, 0, 0, true);

            }
            else if(!creixent && reves)
            {
                result = false;
            }
            else
            {
                result = Ordenat(vectorA,vectorA[index]>=anterior, vectorA[index], index + 1, reves);
            }
            return result;
        
        }
    }
}
