namespace ex8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            int total = 0;
            Console.WriteLine("Enter: ");
            int input = int.Parse(Console.ReadLine());
            bool isSum = true;
            while (isSum)
            {
                Console.WriteLine("Entra un enter que és la suma dels anteriors: ");
                total += input;
                input = int.Parse(Console.ReadLine());
                if (input != total)
                {
                    isSum = false;
                }
                else
                {
                    score++;
                }
            }
            Console.WriteLine($"Final Score: {score}");
        }
    }
}