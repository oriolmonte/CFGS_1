using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Netflix
{
    internal class NetflixImpl : IDAO
    {
        public const string FILENAME = "raw_titles.csv";
        FileStream fs = null;
        private StreamReader sr = null;
        public List<string> Merge(double minscore, double maxscore)
        {
            throw new NotImplementedException();
        }

        public int Merge(string file1, string file2, string outFileName)
        {
            throw new NotImplementedException();
        }

        public int PreMerge(RawTitle[] titles, string outFileName)
        {
            throw new NotImplementedException();
        }

        public RawTitle[] ReadTitles(int index, int length)
        {
            throw new NotImplementedException();
        }
        // index,id,title,type,release_year,age_certification,runtime,genres,production_countries,seasons,imdb_id,imdb_score,imdb_votes
        public int SelectByGenre(string genre, string outputFile)
        {
            using (fs = new FileStream(FILENAME, FileMode.Open, FileAccess.Read))
            using (sr = new StreamReader(fs))
            using (StreamWriter sw = new StreamWriter(outputFile))
            {
                string input = "HELLO,BYE,"[A,B,C]",34";

                // Expresión regular para dividir por comas, manteniendo intacto el contenido entre comillas
                string pattern = "\"[^\"]*\"|[^,]+";

                // Usamos Regex.Matches para encontrar todas las coincidencias
                var matches = Regex.Matches(input, pattern);

                // Imprimimos los resultados del split
                foreach (var match in matches)
                {
                    Console.WriteLine(match.ToString());
                }
                return 1;
                //int count = 0;
                //string pattern = "\"[^\"]*\"|[^,]+";
                //string linia = sr.ReadLine();
                //while (linia != null)
                //{
                //    List<string> separat = new List<string>();
                //    var matches = Regex.Matches(pattern, linia);
                //    foreach (var match in matches)
                //    {
                //        separat.Add(match.ToString());
                //    }
                //    if (separat[7].Contains(genre))
                //        sw.WriteLine(linia);
                //    sr.ReadLine();
                //}
                //return count;
            }
        }

        public string SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public string SelectByIndex(int index)
        {
            throw new NotImplementedException();
        }

        public List<string> TitlesInRange(string fileSortedByIMDBScore, double minscore, double maxscore)
        {
            throw new NotImplementedException();
        }
    }
}
