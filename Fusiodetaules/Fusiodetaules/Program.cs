using System.Text;
namespace Fusiodetaules

{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] taula1 = { 3, 5, 6, 12, 13, 15, 28 };
            int[] taula2 = { 1, 2, 3, 4, 5, 6, 7, 10, 12, 30 };

            List<int> fusio = new List<int>(); 
            fusio=Comuns(taula1 , taula2);
            List<int> nocum = new List<int>();
            nocum=NoComuns(taula1, taula2);
            Console.WriteLine(ResultPrint(fusio));
            Console.WriteLine(ResultPrint(nocum));
        }

        private static List<int> Comuns(int[] taula1, int[] taula2)
        {
            List<int> result = new List<int>();
            int cursor1=0, cursor2=0;
            while(cursor1<taula1.Length && cursor2<taula2.Length) 
            {
                if (taula1[cursor1] == taula2[cursor2]) 
                {
                    result.Add(taula1[cursor1]);
                    cursor1++;
                    cursor2++;
                }             
                else if (taula1[cursor1]<taula2[cursor2])
                {
                    cursor1++;
                }
                else
                {
                    cursor2++;
                }
            }
            return result;
        }
        private static List<int> NoComuns(int[] taula1, int[] taula2)
        {
            List<int> result = new List<int>();
            int cursor1 = 0, cursor2 = 0;
            while (cursor1 < taula1.Length && cursor2 < taula2.Length)
            {
                if (taula1[cursor1] == taula2[cursor2])
                {
                    cursor1++;
                    cursor2++;
                }
                else if (taula1[cursor1] < taula2[cursor2])
                {
                    result.Add(taula1[cursor1]);
                    cursor1++;
                }
                else
                {
                    result.Add(taula2[cursor2]);
                    cursor2++;
                }
            }
            for(cursor1=cursor1; cursor1 < taula1.Length;cursor1++)
            {
                result.Add(taula1[cursor1]);
            }

            for (cursor2= cursor2; cursor2 < taula2.Length; cursor2++)
            {
                result.Add(taula2[cursor2]);
            }
            return result;
        }
        public static String ResultPrint(List<int>result)
        {
            StringBuilder cadena = new StringBuilder();
            if (result.Count != 0)
            {
                cadena.Append("{ ");
                for (int i = 0; i < result.Count-1; i++)
                {
                    cadena.Append(result[i].ToString() + ", ");
                }
                cadena.Append(result[result.Count-1].ToString()+" }\n");
            }
            else
            {
                cadena.Append("{}\n");
            }
            return cadena.ToString();
        }
    }
}