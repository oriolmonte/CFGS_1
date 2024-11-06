namespace Deadlocks
{
    internal class Program
    {
        private static string[] accountFiles = { "client0.txt", "client1.txt", "client2.txt" };
        private static Mutex[] accountMutexes = { new Mutex(), new Mutex(), new Mutex() };
        static Client[] clients;

        public class Client
        {
            public int Saldo { get; set; }
            public Client(int saldo)
            {
                Saldo = saldo;
            }



        }
        static void Main(string[] args)
        {
            try
            {
                Thread[] threads = new Thread[20];
                for (int i = 0; i < 20; i++)
                {
                    threads[i] = new Thread(Transaccio);
                    threads[i].Start();
                    Thread.Sleep(3000);
                    //Afegim retard

                }

                foreach (Thread thread in threads)
                {
                    thread.Join();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine(ex.StackTrace);  
            }
            finally
            {
                Console.WriteLine("Press Enter to close the console...");
                Console.ReadLine(); 
            }

        }


        private static void Transaccio()
        {
            Random random = new Random();
            //escullim 2 clients
            int origen = random.Next(3);
            int final = random.Next(3);
            while (origen == final)
                final = random.Next(3);
            int quant = random.Next(1, 201);
            int primer = Math.Min(origen, final);
            int segon = Math.Max(origen, final);
            //Si la operacio es possible bloquejem el recurs
            Console.WriteLine($"Vull mutex {primer}");
            bool mutexOrigen = accountMutexes[primer].WaitOne(0);
            if (mutexOrigen)
            {
                Console.WriteLine($"Tinc mutex {primer}");
            }
            else
            {
                Console.WriteLine($"Esperant mutex {primer}");
                mutexOrigen = accountMutexes[primer].WaitOne();

            }
            Console.WriteLine($"Vull mutex {segon}");
            bool mutexFinal = accountMutexes[segon].WaitOne(0);
            if (mutexFinal)
            {
                Console.WriteLine($"Tinc mutex {segon}");

            }
            else
            {

                Console.WriteLine($"Esperant mutex {segon}");
                mutexFinal = accountMutexes[segon].WaitOne();

            }

            try
            {
                Client cl0 = new Client(GetBalance(0));
                Client cl1 = new Client(GetBalance(1));
                Client cl2 = new Client(GetBalance(2));
                clients = [cl0, cl1, cl2];

                if (mutexOrigen && mutexFinal)
                {
                    if (clients[origen].Saldo - quant >= 0)
                    {
                        clients[origen].Saldo -= quant;
                        clients[final].Saldo += quant;
                        Console.WriteLine($"Transferits {quant} de Client {origen} a Client {final}");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine($"Transaccio de {quant} de Client {origen} a Client {final} fallida");
                    }
                }
            }

            finally
            {
                //alliberem el recurs
                for (int i = 0; i < clients.Length; i++)
                {
                    SetBalance(i, clients[i].Saldo);
                    Console.WriteLine($"Saldo final de client {i} : {GetBalance(i)}");

                }

                if (mutexOrigen) accountMutexes[origen].ReleaseMutex();
                if (mutexFinal) accountMutexes[final].ReleaseMutex();
            }
        }


        private static int GetBalance(int accountIndex)
        {
            string balanceText = File.ReadAllText(accountFiles[accountIndex]);
            if (balanceText != "")

                return int.Parse(balanceText);
            else
                return 0;
        }
        private static void SetBalance(int accountIndex, int newBalance)
        {
            File.WriteAllText(accountFiles[accountIndex], newBalance.ToString());
        }
    }
}
    

