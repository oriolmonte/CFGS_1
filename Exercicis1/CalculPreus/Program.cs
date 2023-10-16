namespace CalculPreus
{
    internal class Program
    {
        public const double IVA = 0.21;
        static void Main(string[] args)
        {
            double importBrut, iva, importNet, importRaw;
            Console.OutputEncoding=System.Text.Encoding.UTF8;
            Console.Write("IMPORT BRUT DE LA VENDA --->");
            importRaw = Math.Round(Convert.ToDouble(Console.ReadLine()),2);
            Console.Write("PERCENTATGE DESCOMPTE (0 A 100) --->");
            double percDescompte = Math.Round(Convert.ToDouble(Console.ReadLine())*0.01, 2);
            importBrut = importRaw - (importRaw * percDescompte);
            iva = Math.Round(importBrut*IVA,2);
            importNet = importBrut + iva;
            Console.WriteLine("IMPORT VENDA : \t\t" + importRaw +"€");
            Console.WriteLine("DESCOMPTE (" + percDescompte * 100 + "%): \t" + importBrut*percDescompte + "€");
            Console.WriteLine("IMPORT VENDA SENSE IVA: " + importBrut + "€");
            Console.WriteLine("IVA(" + IVA * 100 + "%): \t\t" + iva + "€");
            Console.WriteLine("IMPORT FINAL : \t\t" + importNet + "€");
        }
    }
}