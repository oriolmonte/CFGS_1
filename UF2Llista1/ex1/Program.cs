namespace ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] test = { 1, 0, 2 };
            string resultat;
            for(int i = 0; i < test.Length; i++) 
            {
                resultat = ParellSenar(test[i]);
                Console.WriteLine($"El número {test[i]} és {resultat}");            
            }
        }
        public static string ParellSenar(int numero)
        {
            string final;
            if (numero % 2 == 0)
                final = "Parell";
            else
                final = "Senar";
            return final;
        }
    }
}