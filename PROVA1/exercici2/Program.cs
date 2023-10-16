namespace exercici2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DECLAREM VARIABLES
            double salari1, salari2, salari3;
            double bSalari1, bSalari2, bSalari3;
            //USUARI ENTRA DADES
            //Codifiquem en utf-8, no troba el caràcter "€"
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Primer Salari");
            salari1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Segon Salari");
            salari2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Tercer Salari");
            salari3 = Convert.ToDouble(Console.ReadLine());
            //CALCULEM L'AUGMENT
            bSalari1 = Math.Round(salari1 * 1.1, 2);
            bSalari2 = Math.Round(salari2 * 1.2, 2);
            bSalari3 = Math.Round(salari3 * 1.3, 2);
            //OUTPUT
            Console.WriteLine("El primer treballador cobrava " + salari1 + "€ i ara cobra " + bSalari1 + "€");
            Console.WriteLine("El segon treballador cobrava " + salari2 + "€ i ara cobra " + bSalari2 + "€");
            Console.WriteLine("El tercer treballador cobrava " + salari3 + "€ i ara cobra " + bSalari3 + "€");

        }
    }
}