namespace ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Equip Local");
            string equipLocal = Console.ReadLine();
            Console.WriteLine("Equip Visitant");
            string equipVisitant = Console.ReadLine();
            Console.WriteLine("Gols Local");
            int golsLocal = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Gols Visitant");
            int golsVisitant = Convert.ToInt32(Console.ReadLine());
            if (golsLocal > golsVisitant)
            {
                Console.WriteLine($"El {equipLocal} guanyat al {equipVisitant} {golsLocal} a {golsVisitant}");
            }
            else if (golsLocal < golsVisitant)
            {
                Console.WriteLine($"El {equipLocal} perdut contra el {equipVisitant} {golsLocal} a {golsVisitant}");
            }
            else
                Console.WriteLine("Empat");
        }
    }
}