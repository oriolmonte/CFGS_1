namespace Exercici2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string equipLocal, equipVisitant;
            int golsLocal, golsVisitant;
            Console.WriteLine("Equip local:");
            equipLocal = Console.ReadLine();
            Console.WriteLine("Gols equip local:");
            golsLocal = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Equip Visitant:");
            equipVisitant = Console.ReadLine();
            Console.WriteLine("Gols equip visitant");
            golsVisitant = Convert.ToInt32(Console.ReadLine());
            if (golsLocal == golsVisitant)
            {
                Console.WriteLine("El " + equipLocal + " ha empatat amb el " + equipVisitant + " amb un resultat de " + golsLocal + " a " + golsVisitant);
            }
            else if (golsLocal > golsVisitant)
            {
                Console.WriteLine("El " + equipLocal + " ha guanyat contra el " + equipVisitant + " amb un resultat de " + golsLocal + " a " + golsVisitant);
            }
            else
            {
                Console.WriteLine("El " + equipLocal + " ha perdut contra el " + equipVisitant + " amb un resultat de " + golsLocal + " a " + golsVisitant);

            }
        }
    }
}