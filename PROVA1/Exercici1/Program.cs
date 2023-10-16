namespace Exercici1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DECLAREM
            double nota1, nota2, nota3, nota4, nota5;
            double avg;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //USUARI ENTRA DADES
            Console.WriteLine("Primer Exàmen");
            nota1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Segon Exàmen");
            nota2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Tercer Exàmen");
            nota3 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Quart Exàmen");
            nota4 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Cinquè Exàmen");
            nota5 = Convert.ToDouble(Console.ReadLine());
            //CALCULEM MITJANA PER 5 NOTES SENSE DECIMALS
            avg = (nota1+nota2+nota3+nota4+nota5)*0.2;
            avg = Math.Round(avg, 0);
            //SORTIDA
            Console.WriteLine("MITJANA DEL TRIMESTRE --> " + avg);

        }
    }
}