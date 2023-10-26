namespace ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("bonus.txt");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Random random = new Random();
            double totalCalers = 0;
            string entrada = " ";
            int bonusCount = 0;
            int dinersBonus = 0;
            int countTotal = 0;
            float winnerPercent = 0; 
            while (entrada != null)
            {
                entrada = sr.ReadLine();
                if (entrada == "BONUS") 
                {
                    bonusCount++;
                    countTotal++;
                    dinersBonus += Convert.ToInt32(sr.ReadLine());
                }
                else if (entrada == "NO BONUS")
                {
                    countTotal++;
                }
            }
            sr.Close();
            if(countTotal > 0)
            {
                winnerPercent = bonusCount * 100 / countTotal;
            }
            else
            {
                Console.WriteLine("No Data");
            }
            Console.WriteLine($"Bonus winners : {bonusCount} \nMoney won : {dinersBonus}€\nTotal tickets: {countTotal} \nWinner % : {winnerPercent}");
        }
    }
}