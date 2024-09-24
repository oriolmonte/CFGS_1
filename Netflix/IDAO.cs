using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix
{
    public interface IDAO
    {
        int SelectByGenre(String genre, String outputFile);
        String SelectByIndex(int index);
        String SelectById(int id);
        RawTitle[] ReadTitles(int index, int length);
        int PreMerge(RawTitle[] titles, String outFileName);
        int Merge(string file1,string file2, string outFileName);
        List<String> TitlesInRange(string fileSortedByIMDBScore, double minscore, double maxscore);
    }
}
