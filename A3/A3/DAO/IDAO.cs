using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3.DAO
{
    public interface IDAO : IDisposable
    {
        int NextPosition(string n);
        List<int> SequenciaDePosicions(string seed);
        string ReadNIF();
        string ReadName();
        int ReadLengthOfName();
        bool IsFeasable(string name, string nif);
        void WriteData(string name, string nif);
        public string Nif { get;}
        public string Name { get;}
        public bool Empty { get;}
        public int LengthOfName { get; }

        public int MaxLengthOfName
        {get;}






    }
}
