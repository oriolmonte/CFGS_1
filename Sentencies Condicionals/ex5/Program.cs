namespace ex5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double notaExamen, notaPractica;
            double notaFinal;
            string notaQual = "";
            Console.WriteLine("Nota examen");
            notaExamen = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Nota practica");
            notaPractica = Convert.ToDouble(Console.ReadLine());
            notaFinal = notaExamen * 0.8 + notaPractica * 0.2;
            if (notaFinal>=0 && notaFinal<=10)
            {
                if (notaFinal < 5)
                {
                    notaQual = "Suspens";
                }
                if (notaFinal >= 5 && notaFinal < 7)
                {
                    notaQual = "Aprovat";
                }
                if (notaFinal >= 7 && notaFinal < 9)
                {
                    notaQual = "Notable";
                }
                if (notaFinal > 9)
                {
                    notaQual = "Excel·lent";
                }
                Console.WriteLine("La nota és " + notaQual);
            }
            else
            {
                Console.WriteLine("Format no vàlid");
            }
        }
    }
}