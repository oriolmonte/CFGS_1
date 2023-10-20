namespace ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = 0;
            double y = 0;
            StreamReader sr = new StreamReader("punts.txt");
            Console.WriteLine("Entra radi de cercle:");
            double radi = Convert.ToDouble(Console.ReadLine());
            string entrada = sr.ReadLine();
            double entradaDouble = 0;
            bool puntCreat = false;
            int count = 1;
            while (entrada != null)
            {
                entradaDouble = Convert.ToDouble(entrada);
                if (count % 2 != 0)
                {
                    x = entradaDouble;
                    count++;
                }
                else
                {
                    y = entradaDouble;
                    puntCreat = true;
                    count++;
                }
                if (puntCreat)
                {
                    if (radi < Math.Sqrt(x * x + y * y))
                    {
                        Console.WriteLine($"[{x},{y}] no és dins el cercle");
                    }
                    else
                    {
                        Console.WriteLine($"[{x},{y}] és dins el cercle");
                    }
                    puntCreat = false;
                }
                entrada = sr.ReadLine();
            }
            sr.Close();
        }
    }
}