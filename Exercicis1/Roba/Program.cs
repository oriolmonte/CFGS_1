namespace Roba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Costat de la peça de roba");
            double costat = Convert.ToInt32(Console.ReadLine());
            double radi = costat / 2;
            double areaCercle = Math.PI * Math.Pow(radi, 2);
            double areaQuadrat = Math.Pow(costat, 2);
            double percentageLoss = (100*(areaQuadrat-areaCercle)/areaQuadrat);
            Console.WriteLine("Percentatge Merma = " + Math.Round(percentageLoss,2));
        }
    }
}