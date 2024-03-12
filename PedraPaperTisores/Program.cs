namespace PedraPaperTisores
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Player 1: What's your name?");
            string name = Console.ReadLine();
            PlayerPPT player1 = new PlayerPPT(name);

            Console.WriteLine("Player 2: What's your name?");
            name = Console.ReadLine();
            PlayerPPT player2 = new PlayerPPT(name);

            Console.WriteLine("How many games do you want to play?");

            int games = int.Parse(Console.ReadLine());
            Console.WriteLine(player1.Greeting());
            Console.WriteLine(player2.Greeting());
            for (int i = 0; i < games; i++)
            {
                string resultp1 = player1.Play();
                Console.WriteLine(player1.ShowName() + " : " + resultp1);
                string resultp2 = player2.Play();
                Console.WriteLine(player2.ShowName() + " : " + resultp2);
                int result = Winner(resultp1, resultp2);
                switch (result)
                {
                    case 1:
                        player1.IncreaseScore();
                        Console.WriteLine(player1.ShowName() + " wins.");
                        break;
                    case 2:
                        player2.IncreaseScore();
                        Console.WriteLine(player2.ShowName() + " wins.");
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(player1.ShowScore());
            Console.WriteLine(player2.ShowScore());

        }
        static int Winner(string p1, string p2)
        {
            if (p1 == "Pedra")
            {
                if (p2 == "Tisora")
                    return 1;
                else if (p2 == "Paper")
                    return 2;
                else return -1;

            }
            else if (p1 == "Paper")
            {
                if (p2 == "Tisora")
                    return 2;
                else if (p2 == "Pedra")
                    return 1;
                else return -1;

            }
            else if (p1 == "Tisora")
            {
                if (p2 == "Paper")
                    return 1;
                else if (p2 == "Pedra")
                    return 2;
                else
                    return -1;
            }
            else
                return -1;
        }
    }
}
