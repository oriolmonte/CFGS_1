namespace tonteria1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Tonteries";
            int amplada = Console.WindowWidth;
            int alçada = Console.WindowHeight;
            PintaCaixa(amplada, alçada);
            PintaMenu();
        }
        static void PintaCaixa(int amplada, int alçada)
        {
            for (int i = 0; i < amplada; i++)
            {
                Console.Write("█");

            }
            for (int j = 0; j < alçada; j++)
            {
                Console.SetCursorPosition(0, j);
                Console.Write("█");
            }
            for (int z = 0; z < amplada; z++)
            {
                Console.SetCursorPosition(z, alçada - 1);
                Console.Write("█");
            }
            for (int a = 0; a < alçada; a++)
            {
                Console.SetCursorPosition(amplada - 1, a);
                Console.Write("█");
            }
        }
        static void PintaMenu()
        {
            const int MARGE = 5;
            const int ESPAIAT = 3;
            int fila = 2;
            Console.SetCursorPosition(MARGE,fila);
            Console.Write("1.-Primera Opció");

            Console.SetCursorPosition(MARGE, fila + ESPAIAT);
            Console.Write("2.-Primera Opció");

            Console.SetCursorPosition(MARGE, fila + ESPAIAT*2);
            Console.Write("2.-Primera Opció");

            Console.SetCursorPosition(MARGE, fila + ESPAIAT*3);
            Console.Write("2.-Primera Opció");
            Console.ReadKey();
        }
    }
}