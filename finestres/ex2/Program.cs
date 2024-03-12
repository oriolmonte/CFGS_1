namespace ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int primer, segon, tercer, contador;
            bool trobat = false;
            Random r = new Random();
            primer = r.Next(1,7);
            segon = r.Next(1,7);
            tercer = r.Next(1,7);
            contador = 3;
            trobat = segon == (tercer + primer);
            while(!trobat)
            {
                primer = segon;
                segon = tercer;
                tercer=r.Next(1,7);
                contador++;
                trobat = segon == (tercer + primer);
            }
            Console.WriteLine($"{segon}={tercer}+{primer} Tirades={contador}");
        }
    }
}