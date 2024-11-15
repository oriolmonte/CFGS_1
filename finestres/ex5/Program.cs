﻿namespace ex5
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
                    IncrementMes(ref mes, ref any);
                    tendenciaAnterior = CalcTendencia(anterior, actual);
                    cursor = sr.ReadLine();
                    /*Considerem tendència com 2 mesos seguits de creixement o decreixement.
                    //S'invertirà tendència si durant el periode anterior de canvi hi ha hagut delta i en el següent delta invertida
                    //Un estancament no es invertible,Estancarse no es invertir la tendència. 
                    //(No tendència = 0, tendencia pos = + tendencia neg = -*/
                    while (cursor != null && tendenciaAnterior == ESTANCAT)
                    {
                        actual = int.Parse(cursor);
                        IncrementMes(ref mes, ref any);
                        tendenciaAnterior = CalcTendencia(anterior, actual);
                        anterior = actual;
                        cursor = sr.ReadLine();
                    }
                    //primer element trobat
                    //Cerquem una inversió de la tendència trobada
                    while (cursor != null && !tendenciaInv)
                    {
                        anterior = actual;
                        actual = int.Parse(cursor);
                        tendenciaActual = CalcTendencia(anterior, actual);
                        IncrementMes(ref mes, ref any);
                        if (tendenciaActual != ESTANCAT)
                        {
                            if (tendenciaActual != tendenciaAnterior)
                                tendenciaInv = true;
                            tendenciaAnterior = tendenciaActual;
                        }
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