using System.Text;
namespace ProcessadorText
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string FILENAME = "frases.txt";
            String linia;
            List<string> lines = ProcessarText(FILENAME);
            MostrarFrases(lines);

        }
        private static List<string> ProcessarText(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            List<String> frases = new List<String>();
            String cursor = sr.ReadLine();
            StringBuilder fraseSingle = new StringBuilder();
            while (cursor != null) 
            {
                //Mentre siguem en una frase
                while(cursor != ".")
                {
                    fraseSingle.Append(cursor);
                    cursor = sr.ReadLine();
                    // si no es final de frase afegim espai entre paraules
                    if (cursor != ".")
                    {
                        fraseSingle.Append(' ');
                    }
                }
                //no afegeix strings buides
                if (fraseSingle.ToString() != "")
                {
                    frases.Add(fraseSingle.ToString());
                }
                fraseSingle = fraseSingle.Clear();
                cursor = sr.ReadLine();
            }           
            sr.Close();
            return frases;
        }
        private static void DesglossarFrase(string frase)
        {
            string[] paraules = frase.Split(' ');
            Console.WriteLine($"Numero de paraules de la frase: {paraules.Length}");
            Console.WriteLine("Desglòs de la frase:");
            foreach (string paraula in paraules) 
            {
                Console.WriteLine(paraula);
            }
        }
        private static void MostrarFrases(List<string> frases)
        {
            for (int i = 0; i < frases.Count; i++) 
            {
                Console.WriteLine($"Frase numero {i+1}:");
                Console.WriteLine(frases[i]);
                DesglossarFrase(frases[i]);
                Console.WriteLine("------------------------------------");
            }
        }
    }
}