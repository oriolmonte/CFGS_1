using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasePoker.Model
{
    public enum Valor
    {
        Dos, Tres, Quatre, Cinc, Sis, Set, Vuit,
        Nou, Deu, Jota, Reina, Rei, As, Joker
    }
    public enum Pal
    {
        Trèbols, Diamants, Cors, Piques
    }

    public class Carta : IComparable<Carta>
    {
        private Pal pal;
        private Valor valor;
        private bool bocaAvall;
        private String dors;


        public Carta() : this(Pal.Piques, Valor.As)
        {
        }
        public Carta(Pal nouPal, Valor nouValor) : this(nouPal, nouValor, "Dors01")
        {
        }
        public Carta(Pal nouPal, Valor nouValor, String clauDors)
        {
            pal = nouPal;
            valor = nouValor;
            dors = clauDors;
        }
        public Valor Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        public Pal Pal
        {
            get { return pal; }
            set { pal = value; }
        }
        public bool BocaAvall
        {
            get { return bocaAvall; }
            set { bocaAvall = value; }
        }

        public int CompareTo(Carta other)
        {
            if (this.Valor == other.Valor)
                return this.Pal - other.Pal;
            else
                return this.Valor - other.Valor;
        }

        /// <summary>
        /// Retorna la clau per obtenir el recurs d'imatge de la carta definit al diccionari de recursos
        /// Si la carta està 
        /// </summary>
        public String ClauImatge
        {
            get
            {
                String resultat = "";
                switch (Valor)
                {
                    case Valor.As:
                        resultat = "A";
                        break;
                    case Valor.Rei:
                        resultat = "K";
                        break;
                    case Valor.Reina:
                        resultat = "Q";
                        break;
                    case Valor.Jota:
                        resultat = "J";
                        break;
                    default:
                        resultat = (((int)Valor + 2).ToString());
                        break;
                }

                switch (Pal)
                {
                    case Pal.Piques:
                        resultat += "P";
                        break;
                    case Pal.Cors:
                        resultat += "C";
                        break;
                    case Pal.Diamants:
                        resultat += "D";
                        break;
                    case Pal.Trèbols:
                        resultat += "T";
                        break;
                    default:
                        resultat = (((int)Valor).ToString());
                        break;
                }

                if (Valor == Valor.Joker)
                {
                    resultat = (Pal == Pal.Piques) || (Pal == Pal.Trèbols) ? "Joker1" : "Joker2";
                }
                return bocaAvall ? dors : resultat;
            }
        }
    }

}
