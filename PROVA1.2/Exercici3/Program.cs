namespace Exercici3
{
    internal class Program
    {
        const double BAIXAPRODUCCIO = 18;
        static void Main(string[] args)
        {
            double ous1, ous2, ous3, ous4, totalOus;
            double avgOus, percentOus1, percentOus2, percentOus3, percentOus4;
            string alerta;
            //INPUT USUARI
            Console.Write("Entra els ous del primer trimestre: ");
            ous1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Entra els ous del segon trimestre: ");
            ous2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Entra els ous del tercer trimestre: ");
            ous3 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Entra els ous del quart trimestre: ");
            ous4 = Convert.ToInt32(Console.ReadLine());
            //CAULCUL TOTAL I MITJANA
            totalOus = ous1 + ous2 + ous3 + ous4;
            avgOus = totalOus / 4;
            Console.WriteLine($"\nLa mitjana és de {avgOus} per trimestre\n");
            //CALCUL PERCENTATGE
            percentOus1 = Math.Floor((100 * ous1) / totalOus);
            percentOus2 = Math.Floor((100 * ous2) / totalOus);
            percentOus3 = Math.Floor((100 * ous3) / totalOus);
            percentOus4 = Math.Floor((100 * ous4) / totalOus);
            //CRIDA A ALERTA I OUTPUT, ENS TORNA STRING BUIDA SI NO HI HA ALERTA
            alerta = Alerta(percentOus1);
            Console.WriteLine($"El primer trimestre s'han produït un {percentOus1}% del total. {alerta}");
            alerta = Alerta(percentOus2);
            Console.WriteLine($"El segon trimestre s'han produït un {percentOus2}% del total. {alerta}");
            alerta = Alerta(percentOus3);
            Console.WriteLine($"El tercer trimestre s'han produït un {percentOus3}% del total. {alerta}");
            alerta = Alerta(percentOus4);
            Console.WriteLine($"El quart trimestre s'han produït un {percentOus4}% del total. {alerta}");
        }
        static string Alerta(double percentOus)
        {
            string alerta = "";
            if (percentOus <= BAIXAPRODUCCIO) 
            {
                alerta = "(ALARMA!!! Baixa Produccio.)";
                return alerta;
            }
            else 
            {
                return alerta;
            }
        }
    }
    

}