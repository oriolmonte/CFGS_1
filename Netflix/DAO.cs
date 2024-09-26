using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Netflix
{
    internal class NetflixImpl : IDAO
    {
        readonly CultureInfo culture = new CultureInfo("en-US");
        public const string FILENAME = "raw_titles.csv";
        FileStream fs = null;
        private StreamReader sr = null;
        private StreamReader sr2 = null;

        public int Merge(string file1, string file2, string outFileName)
        {
            using(sr = new StreamReader(file1)) 
            using(sr2 = new StreamReader(file2))
            using (StreamWriter sw = new StreamWriter(outFileName))
            {
                string fileOne = sr.ReadLine();
                string fileTwo = sr2.ReadLine();

                while(fileOne != null && fileTwo!=null)
                {
                    if (double.Parse(fileOne.Split()[^1],culture) < double.Parse(fileTwo.Split()[^1],culture))
                    {
                        sw.WriteLine(fileOne);
                        fileOne=sr.ReadLine();
                    }
                    else if(double.Parse(fileOne.Split()[^1], culture) == double.Parse(fileTwo.Split()[^1], culture))
                    {
                        sw.WriteLine(fileOne);
                        sw.WriteLine(fileTwo);
                        fileOne = sr.ReadLine();
                        fileTwo = sr2.ReadLine();

                    }
                    else
                    {
                        sw.WriteLine(fileTwo);
                        fileTwo=sr2.ReadLine();
                    }
                }
                while(fileOne!=null)
                {
                    sw.WriteLine(fileOne);
                    fileOne = sr.ReadLine();
                }
                while(fileTwo!=null)
                {
                    sw.WriteLine(fileTwo);
                    fileTwo = sr2.ReadLine();
                }
            }
            return 1;
        }

        public int PreMerge(RawTitle[] titles, string outFileName)
        {
            using (fs = new FileStream(FILENAME, FileMode.Open, FileAccess.Read))
            using (StreamWriter sw = new StreamWriter(outFileName))
            {
                int count = 0;
                foreach (var title in titles)
                {
                    sw.WriteLine(title);
                    count++;
                }
                return count;
            }

        }

        public RawTitle[] ReadTitles(int index, int length)
        {
            using (fs = new FileStream(FILENAME, FileMode.Open, FileAccess.Read))
            using (sr = new StreamReader(fs))
            {
                string linia = sr.ReadLine();
                linia = sr.ReadLine();
                int current = 0;
                RawTitle[] ret = new RawTitle[length];
                while (linia != null && current<index-1) 
                {
                    current = Convert.ToInt32(linia.Split(',')[0]);
                    linia = sr.ReadLine();
                }
                current = 0;
                while (linia != null && current<length) 
                {
                    string[] cur = linia.Split(",");
                    double votes=0;
                    double score=0;
                    double season=0;
                    if (cur[cur.Length - 1]!="")
                    {
                         votes= Convert.ToDouble(cur[^1], culture);
                    }
                    if (cur[cur.Length - 2] != "")
                    {
                        score = Convert.ToDouble(cur[^2], culture);
                    }
                    if (cur[cur.Length - 4] != "")
                    {
                        season = Convert.ToDouble(cur[^4], culture);
                    }
                    ret[current] = new RawTitle(Convert.ToInt32(cur[0]), cur[1], cur[2], Convert.ToInt32(cur[4]), season, score, votes);
                    linia = sr.ReadLine();
                    current++; 
                }
                return ret;
                     
            }


        }
        public int SelectByGenre(string genre, string outputFile)
        {
            using (fs = new FileStream(FILENAME, FileMode.Open, FileAccess.Read))
            using (sr = new StreamReader(fs))
            using (StreamWriter sw = new StreamWriter(outputFile))
            {
                    
                int count = 0;
                string pattern = "(?:\"[^\"]*\"|[^,]+)";
                string linia = sr.ReadLine();
                while (linia != null)
                {
                    List<string> separat = new List<string>();
                    var matches = Regex.Matches(linia, pattern);
                 
                    if (matches[7].ToString().Contains(genre))
                    {
                        sw.WriteLine($"{matches[0]},{matches[1]},{matches[2]},{matches[7]}");
                        count++;
                    }
                    linia= sr.ReadLine();
                }   
                return count;
            }
        }

        public string SelectById(string id)
        {
            using (fs = new FileStream(FILENAME, FileMode.Open, FileAccess.Read))
            using (sr = new StreamReader(fs))
            {
                string result = null;
                string linia = sr.ReadLine();
                while (linia != null && result == null)
                {
                    if (linia.Split(',')[1] == id)
                    {
                        result = linia;
                    }
                    linia= sr.ReadLine();
                }
                return result;
            }
        }

        public string SelectByIndex(int index)
        {
            using (fs = new FileStream(FILENAME, FileMode.Open, FileAccess.Read))
            using (sr = new StreamReader(fs))
            {
                string result = null;
                string linia = sr.ReadLine();
                while (linia != null && result==null)
                {
                    if (linia.Split(',')[0] == index.ToString())
                    {
                        result=linia;
                    }
                    linia = sr.ReadLine();
                }
                return result;
            }
        }
        public List<string> TitlesInRange(string fileSortedByIMDBScore, double minscore, double maxscore)
        {
            StreamReader sr = null;
            try
            {
                 sr = new StreamReader(fileSortedByIMDBScore);
            }
            catch
            {
                throw new Exception("no existeix arxiu fusionat");
            }
            string cursor = sr.ReadLine();
            double score = 0;
            while (cursor!=null  )
        }
    }
}
