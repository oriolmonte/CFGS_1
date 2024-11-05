namespace Deadlocks
{
    internal class Program
    {
        StreamReader sr0 = null;
        StreamReader sr1 = null;
        StreamReader sr2 = null;
        StreamReader sr3 = null;
        private static Mutex mutex1 = new Mutex(false, "Mutex1");
        private static Mutex mutex2 = new Mutex(false, "Mutex2");
        private static Mutex mutex3 = new Mutex(false, "Mutex3");
        static void Main(string[] args)
        {
            
        }

        bool Correcte (string clientOut, int diners)
        {
            sr0 = new StreamReader ("client"+clientOut+".txt");
            int saldo = int.Parse (sr0.ReadLine ());
            sr0.Close ();
            return (saldo - diners) >= 0;
        }

        void BloqueigVerificacio(string clientOut, string clientIn, int diners)
        {
            if (Correcte (clientOut, diners)) 
            {
                Console.WriteLine($"S'esta intentant establir una operacio entre els clients {clientOut} i {clientIn}");
                Mutex.OpenExisting($"Mutex{clientIn}").WaitOne();
                Mutex.OpenExisting($"Mutex{clientOut}").WaitOne();
                try
                {

                }
            }
            
        }
    }
}
