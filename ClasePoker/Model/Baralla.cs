using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasePoker.Model
{
    public class Baralla : IEnumerable<Carta>
    {

        private Pal[] pals;
        private Valor[] valors;
        List<Carta> cartes;

        public Pal[] Pals
        {
            get { return pals; }
            set
            {
                pals = value;
                CreaBaralla();
            }
        }

        public Valor[] Valors
        {
            get { return valors; }
            set
            {
                valors = value;
                CreaBaralla();
            }
        }

        /// <summary>
        /// Crea una joc de cartes complet, amb tots els pals i tots els valors, però sense comodins.
        /// </summary>
        public Baralla()
        {
            pals = new Pal[] { Pal.Piques, Pal.Cors, Pal.Diamants, Pal.Trèbols };
            valors = new Valor[] {Valor.As, Valor.Dos, Valor.Tres, Valor.Quatre, Valor.Cinc, Valor.Sis,
                                      Valor.Set, Valor.Vuit, Valor.Nou, Valor.Deu, Valor.Jota,
                                      Valor.Reina, Valor.Rei};

            CreaBaralla();
        }


        /// <summary>
        /// Mètode privat que afegeix a una baralla les cartes resultants de combinar els
        /// pals i valors que contenen els atributs "pals" i "valors".
        /// </summary>
        private void CreaBaralla()
        {
            cartes = new List<Carta>();
            //Allibera les cartes utilitzades fins ara
            cartes.Clear();

            //Afegir les noves cartes
            for (int unPal = 0; unPal < pals.Length; unPal++)
                for (int unValor = 0; unValor < valors.Length; unValor++)
                    cartes.Add(new Carta(pals[unPal], valors[unValor]));
        }

        /// <summary>
        /// Remena les cartes contingudes a la baralla
        /// </summary>
        public void Remena()
        {
            Random rGen = new Random();
            List<Carta> novaBaralla = new List<Carta>();

            while (cartes.Count > 0)
            {
                //Tria una carta per eliminar-la.
                int aEliminar = rGen.Next(0, cartes.Count - 1);
                Carta cartaEliminada = (Carta)cartes[aEliminar];
                cartes.Remove(cartaEliminada);
                //Afegeix la carta eliminada a la nova baralla
                novaBaralla.Add(cartaEliminada);
            }
            //Remplaça la baralla vella per la nova amb les cartes barrejades
            cartes = novaBaralla;
        }
        /// <summary>
        /// Propietat que retorna el número de cartes que té la baralla.
        /// </summary>
        public int Count
        {
            get { return cartes.Count; }
        }

        /// <summary>
        /// Indexador que retorna la carta de la baralla que correspon a l'index rebut.
        /// </summary>
        public Carta this[int index]
        {
            get
            {
                if ((index >= 0) && (index < cartes.Count))
                { return ((Carta)cartes[index]); }
                else
                { throw new ArgumentOutOfRangeException("Índex fora de rang"); }
            }
        }

        /// <summary>
        /// Extreu la primera carta de la baralla i la retorna.
        /// </summary>
        /// <returns></returns>
        public Carta Roba()
        {
            if (Count == 0)
                throw new IndexOutOfRangeException("No es pot robar d'una baralla buida");
            Carta carta = cartes[0];
            cartes.RemoveAt(0);
            return carta;
        }

        /// <summary>
        /// Insereix una carta en una posició determinada de la baralla
        /// </summary>
        /// <param name="carta"></param>
        /// <param name="posicio"></param>
        public void Afegeix(Carta carta, int posicio)
        {
            if (Count > posicio)
                throw new IndexOutOfRangeException("La posició màxima a on es pot inserir és: " + Count);

            cartes.Insert(posicio, carta);
        }

        public IEnumerator<Carta> GetEnumerator()
        {
            return ((IEnumerable<Carta>)cartes).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Carta>)cartes).GetEnumerator();
        }
    }
}
