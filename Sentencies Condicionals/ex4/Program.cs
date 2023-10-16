namespace ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int datahora, hora, min, seg;
            Console.WriteLine("Entra una hora en format hhmmss:");
            datahora = int.Parse(Console.ReadLine());
            seg = datahora % 100;
            min = (datahora / 100)%100;
            hora = (datahora / 10000)%100;
            //Contem 24 com 00
            if(hora > 23 || min > 60 || seg > 60)
            {
                Console.WriteLine("Format no vàlid");
            }
            else
            {
                Console.WriteLine("Format vàlid " +  hora + ":" + min + ":" + seg);
            }
        }
    }
}