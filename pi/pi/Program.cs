class Program
{
    static void Main()
    {
        int bucles = int.Parse(Console.ReadLine());

        double pivar = Pi(bucles);
        Console.WriteLine(pivar);
    }

    static double Calcul(int iterador)
    {
        int i = 1;
        double numerador = 1;
        double denominador = 3;
        double numeradorAux = 1;
        double denominadorAux = 3;

        while (i < iterador)
        {
            numerador *= (numeradorAux + 1);
            denominador *= (denominadorAux + 2);
            numeradorAux += 1;
            denominadorAux += 2;
            i += 1;
        }

        return numerador / denominador;
    }

    static double Pi(int bucles)
    {
        int i = 1;
        double suma = 1;

        while (i <= bucles)
        {
            suma += Calcul(i);
            i += 1;
        }

        return 2 * suma;
    }
}
