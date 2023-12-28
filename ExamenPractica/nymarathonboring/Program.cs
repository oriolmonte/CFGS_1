namespace nymarathonboring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hores, minuts, segons, bib, bibGuanyador=0, segonsTotal, segonsTotalGuanyador=int.MaxValue, abandonats=0;
            string name, nameGuanyador="", cursor, tempsGuanyador;
            StreamReader sr = new StreamReader("test.txt");
            cursor = sr.ReadLine();
            while (cursor != null) 
            {
                bib = int.Parse(cursor);
                name = sr.ReadLine();
                hores = int.Parse(sr.ReadLine());
                minuts = int.Parse(sr.ReadLine());
                segons = int.Parse(sr.ReadLine());
                if (hores == 99 && minuts == 99 && segons == 99)
                    abandonats++;
                else
                {
                    segonsTotal = ToSeconds(hores,minuts,segons);
                    if (segonsTotal < segonsTotalGuanyador)
                    {
                        segonsTotalGuanyador = segonsTotal;
                        bibGuanyador = bib;
                        nameGuanyador = name;
                    }  
                }
                cursor = sr.ReadLine();                
            }
            if(bibGuanyador > 0)
            {

                tempsGuanyador = ToHHmmss(segonsTotalGuanyador).ToString("HH:mm:ss");
                Console.WriteLine($"THE WINNER IS: {bibGuanyador} - {nameGuanyador} TIME ELAPSED: {tempsGuanyador}");
            }
            if (abandonats > 0)
            {
                Console.WriteLine($"# D'ABANDONATS: {abandonats}");
            }
            
        }
        static int ToSeconds(int hours, int minutes, int seconds)
        {
            return(hours * 3600 + minutes * 60 + seconds);
        }
        static DateTime ToHHmmss(int seconds)
        {
            DateTime dateTime = DateTime.Today;
            dateTime = dateTime.AddSeconds(seconds);
            return dateTime;
        }
    }
}