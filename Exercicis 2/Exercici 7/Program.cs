using System.Dynamic;

namespace Exercici_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int import, edat;
            double descompte, importfinal;
            Console.WriteLine("Import:");
            import = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Edat");
            edat = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Descompte");
            descompte = (Convert.ToInt32(Console.ReadLine())) * 0.01;
            if (edat>=18)
            {
                importfinal = import-import * descompte;
                Console.WriteLine("L'import final per majors d'edat és: " + importfinal);
            }
            else
            {
                Console.WriteLine("L'import per menors és: " + import + " no s'aplica descompte");
            }
        }
    }
}