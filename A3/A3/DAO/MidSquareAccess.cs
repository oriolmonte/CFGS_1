using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace A3.DAO
{
    public class MidSquareAccess : IDisposable, IDAO
    {
        const int POS_NOM = 10000;
        private FileStream fs = null;
        private BinaryReader br = null;
        private BinaryWriter bw = null;
        string seed;
        List<int> posicionsValides = new List<int>();


        public string Nif
        {
            get
            {
                if (!Empty)
                    return ReadNIF();
                else
                    return "";
            }
        }
        public string Name { 

            get
            {
                if (!Empty)
                    return ReadName();
                else
                    return "";
            }
        }
        public int LengthOfName { get => ReadLengthOfName(); }

        public int MaxLengthOfName
        {
            get
            {
                if (posicionsValides.Count - 9 >= 0)
                    return posicionsValides.Count - 9;
                else
                    return 0;
                
            }
        }
        public bool Empty
        {
            get
            {
                return LengthOfName == 0;
            }
        }

        public MidSquareAccess(string seed)
        {
            this.seed = seed;
            posicionsValides = SequenciaDePosicions(seed);
            fs = new FileStream($"{seed}.bin", FileMode.OpenOrCreate);
            
        }

        public void Dispose()
        {
            fs?.Dispose();
            bw?.Dispose(); 
            br?.Dispose();
        }

        public bool IsFeasable(string name, string nif)
        {
            return name.Length + nif.Length <= posicionsValides.Count;
        }

        public int NextPosition(string n)
        {
            int num = int.Parse(n);
            int n2 = num * num;
            string n2String = n2.ToString();
            while (n2String.Length > 4) 
            {
                n2String = n2String.Remove(0, 1);
                n2String = n2String.Remove(n2String.Length - 1, 1);
            }
            return int.Parse(n2String);
        }
        
        public int ReadLengthOfName()
        {
            int result;
            if (fs == null)
            {
                fs = new FileStream($"{seed}.bin", FileMode.Open);
            }
            br = new BinaryReader(fs);
            br.BaseStream.Seek(10000, SeekOrigin.Begin);
            try
            {
                result = br.ReadInt32();
            }
            catch
            (Exception e)
            {
                result = 0;
            }
            
            return result;
        }

        public string ReadName()
        {
            br = new BinaryReader(fs);
            string r = "";
            for (int i = 0; i < LengthOfName; i++)
            {
                br.BaseStream.Seek(posicionsValides[i], SeekOrigin.Begin);
                r += br.ReadChar();
            }
            return r;
        }

        public string ReadNIF()
        {
            br = new BinaryReader(fs);
            string r = "";
            for (int i = 0; i < 9; i++) 
            {
                br.BaseStream.Seek(posicionsValides[LengthOfName+i], SeekOrigin.Begin);
                r+=br.ReadChar();
            }
            return r;


        }

        public List<int> SequenciaDePosicions(string seed)
        {
            List<int> list = new List<int>();   
            string seed2 = seed;
            for (int i = 0; i<10000; i++)
            {
                int result = NextPosition(seed2);
                list.Add(result);
                seed2 = result.ToString();
            }
            list = list.Distinct().ToList();
            return list;
        }

        public void WriteData(string name, string nif)
        {
            bw = new BinaryWriter(fs);
            int longitud = name.Length;
            bw.Seek(10000, SeekOrigin.Begin);
            bw.Write(longitud);
            for (int i = 0;i<name.Length;i++)
            {
                bw.Seek(posicionsValides[i], SeekOrigin.Begin);
                bw.Write((byte)name[i]);
            }
            for(int i = 0;i<nif.Length;i++) 
            {
                bw.Seek(posicionsValides[name.Length+i], SeekOrigin.Begin);
                bw.Write((byte)nif[i]);
            }
            bw.Flush();
        }
    }
}
