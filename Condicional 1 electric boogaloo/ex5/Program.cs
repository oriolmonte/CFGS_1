namespace ex5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double examen, practiques, notaFinal;
            Console.WriteLine("Nota Examen");
            examen = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nota Practiques");
            practiques = Convert.ToInt32(Console.ReadLine());
            if (examen < 3 ||  practiques < 3) 
            {
                Console.WriteLine("Suspens");
            }
            else
            {
                examen *=0.8;
                practiques *= 0.2;
                notaFinal = examen + practiques;
                Console.Write($"Nota Final: {notaFinal} ");
                if (notaFinal > 10 || notaFinal < 0) 
                {
                    Console.WriteLine("Nota no vàlida");
                }
                else if (notaFinal < 5) 
                {
                    Console.WriteLine("Suspens");
                }
                else if (notaFinal >= 5 && notaFinal < 7)
                {
                    Console.WriteLine("Aprovat");
                }
                else if (notaFinal >= 7 && notaFinal < 9)
                {
                    Console.WriteLine("Notable");
                }
                else if (notaFinal >= 9  && notaFinal < 10)
                {
                    Console.WriteLine("Excel·lent");
                }
                else
                {
                    Console.WriteLine("Matricula d'Honor");
                }
            }
        }
    }
}