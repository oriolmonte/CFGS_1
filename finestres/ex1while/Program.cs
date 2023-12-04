namespace ex1while
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            int[] finestra = new int[4];
            string cursor;
            bool trobat = false;
            int total = 0;
            StreamReader sr = new StreamReader("test.txt");
            cursor = sr.ReadLine();
            int i = 0;
            while(cursor!=null && i<finestra.Length-1)
            {
                finestra[i]=int.Parse(cursor);
                i++;
                cursor = sr.ReadLine();
            }
            if(i<finestra.Length-1)
            {
                Console.WriteLine("No hi ha prou dades");
                return;
            }
            while(cursor!= null && !trobat)
            {

                finestra[finestra.Length - 1] = int.Parse(cursor);
                int resultat = finestra[finestra.Length - 1];
                for (int j = 0; j<finestra.Length-1; j++) 
                {
                    total += finestra[j];
                }
                if (total == resultat)
                {
                    trobat = true;
                }
                else
                { 
                    for(int p = 0; p < finestra.Length-1;  p++) 
                    {
                        finestra[p] = finestra[p+1];
                    }
                    total = 0;
                    cursor = sr.ReadLine();
                }
            }
            sr.Close();
            if (trobat) 
            {
                string output = "";
                for (int z = 0; z < finestra.Length; z++)
                {
                    if (z == finestra.Length - 2)
                    {
                        output += $"{finestra[z]}";
                    }
                    else if (z == finestra.Length -1)
                        output += $" = {finestra[z]}";
                    else
                        output += $"{finestra[z]} + ";
                }
                Console.WriteLine(output);
            }
            else
                Console.WriteLine("No trobat");
        }
    }
}