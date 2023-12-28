namespace ex5b
{
    internal class Program
    {
        public const int ESTANCAT = 0;
        public const int CREIXENT = 1;
        public const int DECREIXENT = -1;
        static void Main(string[] args)
        {
            string cursor;
            int mes = 1, any = 1990, actual, anterior;
            int tendenciaAnterior = 0, tendenciaActual = 0;
            bool tendenciaInv = false;
            StreamReader sr = new StreamReader("test.txt");
            cursor = sr.ReadLine();
            if (cursor == null)
                Console.WriteLine("Empty File");
            else
            {
                anterior = int.Parse(cursor);
                cursor = sr.ReadLine();
                if (cursor == null)
                    Console.WriteLine("Només una dada");
                else
                {
                    actual = int.Parse(cursor);
                    //Si passem parametres com a referencia podem fer-ho en una funcio
                    IncrementMes(ref mes, ref any);
                    tendenciaAnterior = CalcTendencia(anterior, actual);
                    cursor = sr.ReadLine();
                    while (cursor != null && tendenciaAnterior == ESTANCAT)
                    {
                        anterior = actual;
                        actual = int.Parse(cursor);
                        IncrementMes(ref mes, ref any);
                        tendenciaAnterior = CalcTendencia(anterior, actual);
                        cursor = sr.ReadLine();
                    }
                    while (cursor != null && !tendenciaInv)
                    {
                        anterior = actual;
                        actual = int.Parse(cursor);
                        IncrementMes(ref mes, ref any);
                        tendenciaActual = CalcTendencia(anterior, actual);
                        if (tendenciaActual != 0 && tendenciaActual != tendenciaAnterior)
                            tendenciaInv = true;
                        else
                            cursor = sr.ReadLine();
                    }
                    sr.Close();
                    if (tendenciaInv)
                    {
                        if (tendenciaActual == CREIXENT)
                            Console.WriteLine($"S'ha invertit la tendència negativa el mes {mes} de l'any {any}");
                        else
                            Console.WriteLine($"S'ha invertit la tendència positiva el mes {mes} de l'any {any}");
                    }
                    else
                        Console.WriteLine("No s'ha invertit");
                }
            }
        }
        static int CalcTendencia(int primer, int segon)
        {
            int tendencia;
            if (primer < segon)
                tendencia = CREIXENT;
            else if (primer > segon)
                tendencia = DECREIXENT;
            else
                tendencia = ESTANCAT;
            return tendencia;
        }
        static void IncrementMes(ref int mes, ref int any)
        {
            if ((mes + 1) > 12)
            {
                any++;
                mes = 1;
            }
            else
                mes++;
        }
    }
}