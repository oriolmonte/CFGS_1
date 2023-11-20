namespace ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int primer, segon, tercer, contador=3;
            Random random = new Random();
            bool trobat = false;
            primer = random.Next(1, 7);
            segon = random.Next(1, 7);
            tercer = random.Next(1, 7);
            while(!trobat)
            {
                if (segon == (primer + tercer))
                    trobat = true;
                else
                {
                    primer = segon;
                    segon = tercer;
                    tercer = random.Next(1, 7);
                    contador++;
                }
            }
            // \n es per posar una nova linea a la consola
            Console.WriteLine($"Finestra guanyadora: [{primer},{segon},{tercer}]\n{segon}={primer}+{tercer}\nNombre de tirades: {contador}");
        }
    }
}