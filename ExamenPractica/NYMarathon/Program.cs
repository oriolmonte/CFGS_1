namespace NYMarathon
{
    internal class Program
    {
        class Runner
        {
            public int Bib { get;}
            public string Name { get;}

            public DateTime Time { get;}
            
            public Runner(int bibn, string namen, DateTime timen)
            {
                Bib = bibn;
                Name = namen;
                Time = timen;
            }
        }
        static void Main(string[] args)
        {
            int bib, hours=0, minutes=0, seconds=0, abandonat = 0;
            string name, cursor;
            DateTime time;
            List<Runner> runner = new List<Runner>();
            StreamReader sr = new StreamReader("test.txt");
            cursor = sr.ReadLine();
            while (cursor != null) 
            {
                bib=int.Parse(cursor);
                name = sr.ReadLine();
                hours = int.Parse(sr.ReadLine());
                minutes = int.Parse(sr.ReadLine());
                seconds = int.Parse(sr.ReadLine());
                time = DateTime.Today.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds);
                if (hours != 99 && minutes != 99 && seconds != 99)
                    runner.Add(new Runner(bib, name, time));
                else
                    abandonat++;
                cursor = sr.ReadLine();
            }
            List<Runner> sortedRunner = new List<Runner>();
            if (runner.Count > 0) 
            {
                sortedRunner = runner.OrderBy(x => x.Time).ToList();
            }
            if (sortedRunner.Count>0)
            {
                Console.WriteLine($"THE WINNER IS: {sortedRunner[0].Bib} - {sortedRunner[0].Name} TIME ELAPSED: {sortedRunner[0].Time.ToString("HH:mm:ss")}");

            }
            Console.WriteLine($"# OF ABANDONS {abandonat}");
        }
    }
}