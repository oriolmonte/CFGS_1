namespace ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hora, min, seg;
            Console.WriteLine("Hora hhmmss");
            int horaInput = Convert.ToInt32(Console.ReadLine());
            seg = horaInput % 100;
            min = (horaInput / 100) % 100;
            hora = (horaInput / 10000) % 100;
            Console.WriteLine($"Hora introudida {hora}:{min}:{seg}");
            if (hora > 23 || min > 59 ||  seg > 59)
            {
                Console.WriteLine("Hora Invàlida");
            }
        }
    }
}