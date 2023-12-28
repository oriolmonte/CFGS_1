namespace ex10
{
    internal class Program
    {
        public const double EXAMWEIGHT = 0.2;
        public const double PRACWEIGHT = 0.7;
        public const double ASISTWEIGHT = 0.1;

        public
        static void Main(string[] args)
        {
            int practica, examen, assistencia;
            practica = 10;
            examen = 10;
            assistencia = 50;
            Console.WriteLine(FinalMark(practica, examen, assistencia));
            practica = 0;
            examen = 0;
            assistencia = 100;
            Console.WriteLine(FinalMark(practica, examen, assistencia));
            practica = 10;
            examen = 0;
            assistencia = 0;
            Console.WriteLine(FinalMark(practica, examen, assistencia));
            practica = 0;
            examen = 10;
            assistencia = 0;
            Console.WriteLine(FinalMark(practica, examen, assistencia));

        }
        public static double FinalMark(double practica, double examen, double asist)
        {
            double total = 0;
            bool validPrac = ValidMark(practica);
            bool validExam = ValidMark(examen);
            bool validAsist = asist >= 0 && asist <= 100;
            if (validPrac && validExam && validAsist)
            {
                total = practica * PRACWEIGHT + examen * EXAMWEIGHT + (asist / 10.00 * ASISTWEIGHT);
            }
            else total = -1;
            return total;
        }
        public static bool ValidMark(double mark)
        {
            bool result;
            if(mark<0 || mark>10)
                result=false;
            else
                result=true;
            return result;
        }
    }
}