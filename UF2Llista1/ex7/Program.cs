namespace ex7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hora = 235959;
            int segons = 5;
            int final = IncrementarSegons(hora, segons);
            Console.WriteLine(final);

            hora = 235950;
            segons = 5;
            final = IncrementarSegons(hora, segons);
            Console.WriteLine(final);
        }
        public static int IncrementarSegons(int hora, int segons)
        {
            int horaFinal = hora;
            for (int i = 0; i < segons; i++) 
            {
                horaFinal = IncreaseSecond(horaFinal);
            }
            return horaFinal;
        }
        public static int IncreaseSecond(int value)
        {
            int hora, min, seg;
            hora = value / 10000;
            min = (value % 10000) / 100;
            seg = (value % 100) + 1;
            if (seg == 60)
            {
                seg = 0;
                min++;
                if (min == 60)
                {
                    min = 0;
                    hora++;
                    if (hora == 24)
                    {
                        hora = 0;
                    }
                }
            }
            hora *= 10000;
            min *= 100;
            return hora + min + seg;
        }

    }
}