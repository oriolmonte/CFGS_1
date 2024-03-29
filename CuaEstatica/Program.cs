namespace CuaEstatica
{
    using CuaEstatica;
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ints = new Queue<int>(5);
            Queue<char> chars = new Queue<char>(26);
            for (int i = 'A'; i < 'A' + 26; i++)
            {
                chars.Enqueue((char)i);
            }
            Console.WriteLine("PROVA DE LA CUA ESTATICA");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("CONSTRUCTOR SENSE ARGUMENTS DE ENTERS");
            try
            {
                Queue<int> ints2 = new Queue<int>();
                Console.WriteLine("Correcte");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("CONSTRUCTOR CUA DE CHAR AMB MIDA 26 DE TOTES LES LLETRES DE L'ABECEDARI");

            try
            {
                Queue<char> chars2 = new Queue<char>(26);
                for(int i = 'A'; i < 'A'+26;i++)
                {
                    chars2.Enqueue((char)i);
                }
                Console.WriteLine(chars2);
                Console.WriteLine("Correcte");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("PROPIETAT CUA BUIDA");
            try
            {
                Console.Write("CUA ENTERS:");
                Console.WriteLine(ints.Empty);
                Console.Write("CUA CHARS:");
                Console.WriteLine(chars.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("PROPIETAT CUA PLENA");
            try
            {
                Console.Write("CUA ENTERS:");
                Console.WriteLine(ints.Full);
                Console.Write("CUA CHARS:");
                Console.WriteLine(chars.Full);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("INDEXADOR");
            try
            {
                Console.Write("TERCERA LLETRA DEL ABECEDARI:");
                Console.WriteLine(chars[chars.Count-3]);
                Console.Write("ULTIMA LLETRA DEL ABECEDARI:");
                Console.WriteLine(chars[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("PROPIETAT COUNT");
            try
            {
                Console.Write("CUA ENTERS:");
                Console.WriteLine(ints.Count);
                Console.Write("CUA CHARS:");
                Console.WriteLine(chars.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("DESENCUAR");
            try
            {
                Console.Write("DESENCUEM L'ABECEDARI:");
                Console.WriteLine(chars.DeQueue());
                Console.WriteLine(chars);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("MIREM EL PROXIM EN SORTIR (PEEK)");
            try
            {
                Console.Write("PROXIM EN SORTIR:");
                Console.WriteLine(chars.Peek());
                Console.WriteLine(chars);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("ENCUEM LA LLETRA A");
            try
            {
                chars.Enqueue('A');
                Console.WriteLine(chars);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("ENCUEM UN ARRAY DE INTS");
            try
            {
                ints.Enqueue(new int[] {1,2,3,4,5});
                Console.WriteLine(ints);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("IENUMERATOR|IENUMERABLE");
            Console.WriteLine("--------------------------");
            try
            {
                IEnumerator<int> enumerator = ints.GetEnumerator();
                Console.Write("MOVE NEXT:");
                Console.WriteLine(enumerator.MoveNext());
                Console.Write("CURRENT:");
                Console.WriteLine(enumerator.Current);
                Console.Write("MOVE NEXT:");
                Console.WriteLine(enumerator.MoveNext());
                Console.Write("CURRENT:");
                Console.WriteLine(enumerator.Current);
                Console.WriteLine("--------------------------");
                Console.WriteLine("RESET:");
                enumerator.Reset();
                Console.Write("MOVE NEXT:");
                Console.WriteLine(enumerator.MoveNext());
                Console.Write("CURRENT:");
                Console.WriteLine(enumerator.Current);
                Console.WriteLine("--------------------------");
                Console.WriteLine("YIELD RETURN");
                IEnumerator<int> enumeratoryield = ints.GetEnumeratorYield();
                Console.WriteLine("Correcte");
                Console.Write("MOVE NEXT:");
                Console.WriteLine(enumeratoryield.MoveNext());
                Console.Write("CURRENT:");
                Console.WriteLine(enumeratoryield.Current);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("ToArray");
            try
            {
                int[] intArr = ints.ToArray();
                foreach (int i in intArr)
                {
                    Console.Write(i+" ");
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("Contains");
            try
            {
                Console.Write("ABECEDARI CONTÉ '!': ");
                Console.WriteLine(chars.Contains('!'));

                Console.Write("ABECEDARI CONTÉ 'M': ");
                Console.WriteLine(chars.Contains('M'));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("REQUEUE");
            try
            {
                Console.Write("CUA ORIGINAL");
                Console.WriteLine(ints);

                Console.WriteLine("REENCUEM");
                Queue<int> reencuada = ints.Requeue();
                Console.Write("CUA ORIGINAL");
                Console.WriteLine(ints);
                Console.Write("CUA NOVA");
                Console.WriteLine(reencuada);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
