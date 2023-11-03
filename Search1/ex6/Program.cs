namespace ex6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string entrada;
            int i,len;
            i = 0;
            bool isHacked = true;
            Console.WriteLine("Entra un string");
            entrada = Console.ReadLine().ToLower();
            len = entrada.Length;
            while (isHacked && i<len)
            {
                if (entrada[i] >= 'a' && entrada[i] <= 'z')
                {
                    if (!(entrada[i] == 'a' || entrada[i] == 'e' || entrada[i] == 'o' || entrada[i] == 'i' || entrada[i] == 'u'))
                    {
                        isHacked = false;
                    }
                }
                i += 2;
            }
            if (isHacked)
                Console.WriteLine("By a hacker");
            else
                Console.WriteLine("Not hacked");
        }
    }
}