using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicis1
{
    internal class Daus
    {
        static void Main(string[] args)
        {
            //DECLARACIO DE VARIABLES
            //tipus generador aleatori 
            Random r = new Random();
            //tipus enter
            int primerDau, segonDau, tercerDau;
            int suma;
            //COMANDS DE CONSOLA BUIDA CONSOLA I MOSTRA UN LITERAL STRING
            Console.Clear();
            Console.WriteLine("SIMULACIÓ DEL LLENÇAMENT DE 3 DAUS I OBTENCIÓ DE LA SUMA DELS LLENÇAMENTS ");
            //ASSIGNACIO DE VARIABLES I CALCUL DE DAUS
            primerDau = r.Next(1, 7);
            segonDau = r.Next(6) + 1;
            tercerDau = r.Next(1, 7);
            //OUTPUT DATA   
            suma = primerDau + segonDau + tercerDau;
            //OUTPUT LITERAL EN STRING
            Console.WriteLine("Valor del 1er dau --->" + primerDau);
            Console.WriteLine("Valor del 2n dau --->" + segonDau);
            Console.WriteLine("Valor del 3r dau --->" + tercerDau);
            Console.WriteLine("Suma dels 3 llençaments -->" + suma);

        }
    }
}
