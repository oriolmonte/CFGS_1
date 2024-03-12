namespace letsplayagame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            bool guanyat = false;
            int input, contador=0, random;
            Console.WriteLine("WELCOME TO THE GAME!\n" +
                "IF YOU GET TIRED, ENTER 0 TO END\n");
            Console.Write("ENTER A NUMBER BETWEEN 1 AND 35 -> ");
            input = Convert.ToInt32(Console.ReadLine());
            random = r.Next(1,36);
            contador++;
            while(input != 0 && !guanyat)
            {
                if (random == input)
                    guanyat=true;
                else
                {
                    Console.WriteLine($"SORRY MY HIDDEN NUMBER IS {random}");
                    random = r.Next(1, 36);
                    Console.Write("ENTER A NUMBER BETWEEN 1 AND 35 -> ");
                    input = Convert.ToInt32(Console.ReadLine());
                    contador++;
                }
            }
            Console.Write($"NUMBER OF ATTEMPTS -->{contador}\n");
            if (guanyat)
                Console.WriteLine("CONGRATULATIONS, YOU HAVE WON!");
            else
                Console.WriteLine("GOT TIRED? YOU SHOULD'VE BEEN MORE PATIENT! YOU'VE LOST!");
        }
    }
}