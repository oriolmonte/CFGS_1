namespace ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char lletra = 'a';
            Console.WriteLine($"Input \"{ContainsChar(lletra)}\" contains {lletra}");
        }
        public static string ContainsChar(char c)
        {
            Console.WriteLine($"Escriu frase amb {c}");
            string userS = "";
            bool result = false;
            while (!result)
            {
                try
                {
                    userS = Console.ReadLine();
                    result = userS.Contains(c);
                    if (!result) throw new Exception($"{c} is not contained. Try again.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return userS;
        }
    }
}