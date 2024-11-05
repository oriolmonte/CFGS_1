using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesDirecte.DAO
{
    public class MidSquareAccess : IDisposable, IDAO
    {
        const int POS_NOM = 10000;
        private FileStream fs = null;
        private BinaryWriter bw = null;
        private BinaryReader br = null;
        private string name;
        private string nif;
        List<int> posicionsValides = new List<int>();
        public bool Empty { get; set; }
        public int MaxLength {  get; set; }
        public int LengthOfName { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool IsFeasable(string name, string nif)
        {
            throw new NotImplementedException();
        }

        public int NextPosition(string n)
        {
            throw new NotImplementedException();
        }

        public string ReadLengthOfName()
        {
            throw new NotImplementedException();
        }

        public string ReadName()
        {
            throw new NotImplementedException();
        }

        public string ReadNif()
        {
            throw new NotImplementedException();
        }

        public List<int> SequenciaDePosicions(string seed)
        {
            throw new NotImplementedException();
        }

        public void WriteData(string name, string nif)
        {
            throw new NotImplementedException();
        }
    }
}
