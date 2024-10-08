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

        public void Merge(string file1, string file2, string outFileName)
        {
            using(sr = new StreamReader(file1)) 
            using(sr2 = new StreamReader(file2))
            using (StreamWriter sw = new StreamWriter(outFileName))
            {
                string fileOne = sr.ReadLine();
                string fileTwo = sr2.ReadLine();

                while(fileOne != null && fileTwo!=null)
                {
                    double fileOneDouble = double.Parse(fileOne.Split(";")[^2]);
                    double fileTwoDouble = double.Parse(fileTwo.Split(";")[^2]);
                    if (fileOneDouble < fileTwoDouble)
                    {
                        sw.WriteLine(fileOne);
                        fileOne=sr.ReadLine();
                    }
                    else if(fileOneDouble == fileTwoDouble)
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
            sr.Close();
            sr2.Close();
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
                List<RawTitle> ret = new List<RawTitle>();
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
                    int any = 0;
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
                    if ((cur[4])!="")
                    {
                        try
                        {
                            any = Convert.ToInt32(cur[4]);
                        }
                        catch
                        {
                            any = 0;
                        }
                        
                    }
                    RawTitle afegir = new RawTitle(Convert.ToInt32(cur[0]), cur[1], cur[2], any, season, score, votes);
                   ret.Add(afegir);
                    linia = sr.ReadLine();
                    current++; 
                }
                var final = ret.ToArray();
                Array.Sort(final);
                return final;
                     
            }


        }
        public int SelectByGenre(string genre, string outputFile)
        {
            using (fs = new FileStream(FILENAME, FileMode.Open, FileAccess.Read))
            using (sr = new StreamReader(fs))
            using (StreamWriter sw = new StreamWriter(outputFile))
            {

                string genreCometes = "'" + genre + "'";
                int count = 0;
                string pattern = @",(?=(?:[^""]*""[^""]*"")*[^""]*$)";
                string linia = sr.ReadLine();
                while (linia != null)
                {
                    var matches = Regex.Split(linia, pattern);
                    string generes = matches[7].ToString();
                    if (generes[0]=='"')
                    {
                        generes = generes.Substring(2,generes.Length-4);
                    }
                    else
                    {
                        generes = generes.Substring(1, generes.Length - 2);
                    }
                    var generesS = generes.Split(',');
                    foreach (string genere in generesS)
                    {
                        if (genreCometes == genere.Trim()) //UN GENERE POT CONTENIR EL NOM D'UN ALTRE GENERE...
                        {
                            sw.WriteLine($"{matches[0]},{matches[1]},{matches[2]},{matches[7]}");
                            count++;
                        }
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
                linia = sr.ReadLine();
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
                string indexS = index.ToString();
                linia = sr.ReadLine();
                
                while (linia != null && result==null)
                {
                    string split = linia.Split(',')[0];
                    if (split == indexS)
                    {
                        result = linia;
                        
                    }
                    else if (int.Parse(linia.Split(',')[0]) > index)
                        result = null;
                    linia = sr.ReadLine();
                }
                return result;
            }
        }
        public List<string> TitlesInRange(string fileSortedByIMDBScore, double minscore, double maxscore)
        {
            StreamReader sr = null;
            List<string> result = new List<string>();
            try
            {
                 sr = new StreamReader(fileSortedByIMDBScore);
            }
            catch
            {
                throw new Exception("no existeix arxiu fusionat");
            }
            string cursor = sr.ReadLine();
            double score = double.Parse(cursor.Split(";")[^2],culture);
            while (cursor!=null && score>maxscore)
            {
                cursor = sr.ReadLine();
                score = double.Parse(cursor.Split(";")[^2], culture);
            }
            while (cursor!=null && score>=minscore)
            {
                result.Add(cursor);
                cursor = sr.ReadLine();
                score = double.Parse(cursor.Split(";")[^2], culture);

            }
            sr.Close();
            return result;
        }
    }
}
