namespace ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int anteriorAnterior=0, anterior=0, actual=0;
            string cursor;
            bool trobat = false;
            StreamReader sr = new StreamReader("test.txt");
            cursor = sr.ReadLine();
            if (cursor == null)
                Console.WriteLine("Empty File");
            else
            {
                anteriorAnterior = int.Parse(cursor);
                cursor = sr.ReadLine();
                if (cursor == null)
                    Console.WriteLine("Incorrect Format");
                else
                {
                    anterior = int.Parse(cursor);
                    cursor = sr.ReadLine();
                    while (cursor != null && !trobat)
                    {
                        actual = int.Parse(cursor);
                        //primera finestra acabada
                        if (actual == (anteriorAnterior + anterior))
                        {
                            trobat = true;
                        }
                        else
                        {
                            //següent finestra
                            anteriorAnterior = anterior;
                            anterior = actual;
                            cursor = sr.ReadLine();
                        }
                    }
                }
                if (!trobat)
                {
                    Console.WriteLine("No trobat");
                }
                else
                {
                    Console.WriteLine($"{actual}={anterior}+{anteriorAnterior}");
                }
            }
        }
    }
}