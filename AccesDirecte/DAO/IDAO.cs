using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesDirecte.DAO
{
    public interface IDAO
    {
        int NextPosition(string n);
        List<int> SequenciaDePosicions(string seed);
        string ReadNif();
        string ReadName();
        string ReadLengthOfName();
        bool IsFeasable(string name, string nif);
        void WriteData(string name, string nif);



    }
}
