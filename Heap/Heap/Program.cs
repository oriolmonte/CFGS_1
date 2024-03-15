using System.Text;

namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stackInt = new Stack<int>();
            stackInt.Push(1);
            stackInt.Push(2);
            Console.WriteLine(stackInt.ToString());
            Stack<string> stackString = new Stack<string>();
            string a = "a";
            string b = "b";
            stackString.Push(a);
            stackString.Push(b);
            Console.WriteLine(stackString.ToString());
            Stack<string> stackString2 = new Stack<string>();
            stackString2.Push(a);
            stackString2.Push(b);
            Console.WriteLine($"Equals? {stackString.Equals(stackString2)}");
            string s = stackString.Top;
            Console.WriteLine(s);
            stackString.Pop();            
            Console.WriteLine(stackString.ToString());
            Console.WriteLine($"empty?{stackString.Empty}");
            stackString.Pop();
            Console.WriteLine($"empty?{stackString.Empty}");
            Console.WriteLine($"empty?{stackString.Top}");
        }
    }
    public class Stack <TipusBase>
    {
        private const int MIDA_DEFAULT = 5;
        TipusBase[] _dades;
        int _nelements;

        public Stack()
        {
            _dades = new TipusBase[MIDA_DEFAULT];
            _nelements = 0;
        }
        public Stack(int mida)
        {
            _dades = new TipusBase[mida];
            _nelements = 0;
        }
        public Stack(Stack<TipusBase> stack) 
        {
            _dades = new TipusBase[stack._dades.Length];
            for(int i = 0; i<_dades.Length;i++)
            {
                _dades[i] = stack._dades[i];
            }
            _nelements = stack._nelements;
        }
        public void Push(TipusBase value) 
        {
            if(!Full) 
            {
                _dades[_nelements] = value;
                _nelements++;
            }    
            else
            {
                throw new Exception("Stack Overflow");
            }
        }
        public void Pop()
        {
            if (Empty) throw new Exception("Empty");
            _dades[_nelements - 1] = default;
            _nelements--;

        }
        public bool Full
        {
            get
            {
                bool full = false;
                if(_nelements.Equals(_dades.Length)) 
                {
                    full = true;
                }
                return full;
            }
        }
        public bool Empty
        {
            get
            {
                return _nelements == 0;
            }
            
        }
        public TipusBase Top
        {

            get
            {
                if (!Empty)
                    return _dades[_nelements - 1];
                else
                    throw new Exception("Stack Underflow");
            }
            
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (!Empty)
            {
                sb.Append("[");
                for (int i = 0; i < _nelements; i++)
                {
                    sb.Append(_dades[i].ToString());
                    sb.Append(",");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("]");
            }
            else sb.Append("Empty");
            return sb.ToString();
        }
        public bool Equals(Stack<TipusBase> obj)
        {
            bool areEqual = true;
            if (this is null) areEqual = false;
            else if (obj is Stack<TipusBase>)
            {
                Stack<TipusBase> entrada = new Stack<TipusBase>(obj);
                if (_nelements != entrada._nelements) areEqual = false;
                else
                {
                    int i = 0;
                    while (areEqual && i < _nelements)
                    {
                        areEqual = _dades[i].Equals(entrada._dades[i]);
                        i++;
                    }
                }
            }
            else areEqual = false;
            return areEqual;
        }
    }

}
