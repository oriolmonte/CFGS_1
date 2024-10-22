using System.Threading;
namespace Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            object lockObject = new object();

            // Creem un array de fils
            Thread[] threads = new Thread[5];

            // Funció que cada fil executarà
            void IncrementCounter()
            {
                for (int i = 0; i < 1000; i++)
                {
                    lock (lockObject) // Assegurem que només un fil incrementa el comptador alhora
                    {
                        counter++;
                    }
                }
            }

            // Iniciar els fils
            for (int i = 0; i < 5; i++)
            {
                threads[i] = new Thread(IncrementCounter);
                threads[i].Start();
            }

            // Esperar que tots els fils acabin
            foreach (var thread in threads)
            {
                thread.Join(); // Ens assegurem que tots els fils acabin abans de continuar
            }

            // Mostrar el valor final del comptador
            Console.WriteLine("Valor final del comptador: " + counter);
        }
        public static void Funcio()
        {
            Console.WriteLine("Aquest codi està executant-se en un altre thread.");
        }
    }
}
