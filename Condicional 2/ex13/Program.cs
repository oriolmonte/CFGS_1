namespace ex13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inicial d'aminoàcids: ");
            string inicials = Console.ReadLine().ToLower();
            switch (inicials)
            {
                case "ile":
                    Console.WriteLine("Isoleucina");
                    break;
                case "leu":
                    Console.WriteLine("Leucina");
                    break;
                case "lys":
                    Console.WriteLine("Lisina");
                    break;
                case "met":
                    Console.WriteLine("Metionina");
                    break;
                case "phe":
                    Console.WriteLine("Fenilalanina");
                    break;
                case "thr":
                    Console.WriteLine("Triptófano");
                    break;
                case "val":
                    Console.WriteLine("Valina");
                    break;
                case "his":
                    Console.WriteLine("Histidina");
                    break;
                case "arg":
                    Console.WriteLine("Arginina");
                    break;
                default: 
                    Console.WriteLine("NO CORRESPON A CAP AMINOÀCID");
                    break;
            }
        }
    }
}