    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

namespace ClasePoker.Model
{

    public class Ma : IEnumerable<Carta>
    {

        List<Carta> cartes;
        List<Carta> comodins;
        int millorResultat = -1;
        public int MillorResultat
        {
            
            get
            {
                millorResultat = -1;
                if(cartes.Count!=0) { 
                    Dictionary<int,bool> resultats = new Dictionary<int,bool>();
                    {
                        resultats.Add(0, HiHaEscalaReialDeColor);
                        resultats.Add(1, HiHaEscalaDeColor);
                        resultats.Add(2, HiHaPoker);
                        resultats.Add(3, HiHaFull);
                        resultats.Add(4, HiHaColor);
                        resultats.Add(5, HiHaEscala);
                        resultats.Add(6, HiHaTrio);
                        resultats.Add(7, HiHaDobleParella);                        
                        resultats.Add(8, HiHaParellaMinima(Valor.Jota));                   
                    }
                
                    foreach (var item in resultats)
                    {
                        if (item.Value) 
                        {
                            if (millorResultat == -1 || item.Key < millorResultat)
                            {
                                millorResultat = item.Key; 
                            }
                        }
                    }
                }
                return millorResultat;
            }
        }

        public Ma()
        {
            comodins = new List<Carta>();
            cartes = new List<Carta>();
        }

        public Ma(Carta[] cartes)
        {
            this.cartes = new List<Carta>();
            comodins = new List<Carta>();
            this.cartes.AddRange(cartes);
        }


        /// <summary>
        /// Afegeix una carta la mà
        /// </summary>
        /// <param name="carta"></param>
        public void Afegeix(Carta carta)
        {
            cartes.Add(carta);
        }

        /// <summary>
        /// Afegeix un rang de cartes a la mà
        /// </summary>
        /// <param name="cartes"></param>
        public void AfegeixRang(Carta[] cartes)
        {
            this.cartes.AddRange(cartes);
        }


        public void Elimina(int posicio)
        {
            if (posicio >= Count)
            {
                throw new IndexOutOfRangeException("No es pot eliminar cap carta a la posició: " + posicio);
            }

            cartes.RemoveAt(posicio);
        }



        /// <summary>
        /// Ordena les cartes contingudes a la mà
        /// </summary>
        public void Ordena()
        {
            cartes.Sort();
        }

        /// <summary>
        /// Propietat que retorna el número de cartes que té la mà.
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

            set
            {
                if ((index >= 0) && (index < cartes.Count))
                { cartes[index] = value; }
                else
                { throw new ArgumentOutOfRangeException("Índex fora de rang"); }
            }
        }



        /// <summary>
        /// Obté o assigna quines cartes fan de comodí
        /// </summary>
        public Carta[] Comodins
        {
            get { return comodins.ToArray<Carta>(); }
            set { comodins.Clear(); comodins.AddRange(value); }
        }

        /// <summary>
        /// Descomposa les cartes de la ma en valors
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        private Dictionary<Valor, List<Carta>> DescomposaValors()
        {
            Dictionary<Valor, List<Carta>> resultat = new Dictionary<Valor, List<Carta>>();
            foreach (Valor v in Enum.GetValues(typeof(Valor)))
            {
                resultat.Add(v, new List<Carta>());
            }
            foreach (Carta carta in cartes)
            {
                if (Conte(comodins, carta))
                    resultat[Valor.Joker].Add(carta);
                else
                    resultat[carta.Valor].Add(carta);
            }
            return resultat;
        }


        /// <summary>
        /// Descomposa les cartes de la ma en pals (no considera els comodins)
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        private Dictionary<Pal, List<Carta>> DescomposaPals()
        {
            Dictionary<Pal, List<Carta>> resultat = new Dictionary<Pal, List<Carta>>();
            foreach (Pal v in Enum.GetValues(typeof(Pal)))
            {
                resultat.Add(v, new List<Carta>());
            }
            foreach (Carta carta in cartes)
            {
                if (!Conte(comodins, carta))
                    resultat[carta.Pal].Add(carta);
            }
            return resultat;
        }

        #region comprovació de jugades
        public bool HiHaParella
        {
            get
            {
                Dictionary<Valor, List<Carta>> dic = DescomposaValors();
                bool hiHaParella = dic[Valor.Joker].Count > 0;
                int index = 0;
                while (!hiHaParella && index < dic.Keys.Count)
                {
                    hiHaParella = dic[dic.Keys.ElementAt(index)].Count > 1;
                    index++;
                }
                return hiHaParella;
            }
        }
        public bool HiHaParellaMinima(Valor v)
        {
            Dictionary<Valor, List<Carta>> dic = DescomposaValors();
            bool hiHaParella = dic[Valor.Joker].Count > 0;
            int index = 0;
            while (!hiHaParella && index < dic.Keys.Count)
            {
                hiHaParella = (dic.Keys.ElementAt(index) >= v) && (dic[dic.Keys.ElementAt(index)].Count > 1);
                index++;
            }
            return hiHaParella;
        }

        public bool HiHaDobleParella
        {
            get
            {
                Dictionary<Valor, List<Carta>> dic = DescomposaValors();
                bool hiHaDobleParella = dic[Valor.Joker].Count > 1;
                int index = 0;
                int comptaParelles = 0;
                while (!hiHaDobleParella && index < dic.Keys.Count)
                {
                    if (dic[dic.Keys.ElementAt(index)].Count > 1)
                        comptaParelles++;
                    hiHaDobleParella = (comptaParelles + dic[Valor.Joker].Count) > 1;
                    index++;
                }
                return hiHaDobleParella;
            }
        }

        public bool HiHaTrio
        {
            get
            {
                Dictionary<Valor, List<Carta>> dic = DescomposaValors();
                bool hiHaTrio = dic[Valor.Joker].Count > 1;
                int index = 0;
                while (!hiHaTrio && index < dic.Keys.Count)
                {
                    hiHaTrio = (dic.Keys.ElementAt(index) != Valor.Joker) && (dic[dic.Keys.ElementAt(index)].Count + dic[Valor.Joker].Count) > 2;
                    index++;
                }
                return hiHaTrio;
            }
        }

        public bool HiHaPoker
        {
            get
            {
                Dictionary<Valor, List<Carta>> dic = DescomposaValors();
                bool hiHaPoker = dic[Valor.Joker].Count > 2;
                int index = 0;
                while (!hiHaPoker && index < dic.Keys.Count)
                {
                    hiHaPoker = (dic.Keys.ElementAt(index) != Valor.Joker) && (dic[dic.Keys.ElementAt(index)].Count + dic[Valor.Joker].Count) > 3;
                    index++;
                }
                return hiHaPoker;
            }
        }

        public bool HiHaQuatreDosos
        {
            get
            {
                Dictionary<Valor, List<Carta>> dic = DescomposaValors();
                return dic[Valor.Dos].Count >= 4;
            }
        }
        public bool HiHaRepoker
        {
            get
            {
                Dictionary<Valor, List<Carta>> dic = DescomposaValors();
                bool hiHaRepoker = dic[Valor.Joker].Count > 3;
                int index = 0;
                while (!hiHaRepoker && index < dic.Keys.Count)
                {
                    hiHaRepoker = (dic.Keys.ElementAt(index) != Valor.Joker) && (dic[dic.Keys.ElementAt(index)].Count + dic[Valor.Joker].Count) > 4;
                    index++;
                }
                return hiHaRepoker;
            }
        }
        public bool HiHaFull
        {
            get
            {
                Dictionary<Valor, List<Carta>> dic = DescomposaValors();
                bool hiHaFull = false;
                int max1 = 0;
                int max2 = 0;
                int nComodins = dic[Valor.Joker].Count;
                foreach (Valor v in dic.Keys)
                {
                    if (v != Valor.Joker)
                    {
                        if (dic[v].Count > max1)
                        {
                            max2 = max1;
                            max1 = dic[v].Count;
                        }
                        else if (dic[v].Count > max2)
                        {
                            max2 = dic[v].Count;
                        }
                    }
                }
                while (max2 < 2 && nComodins > 0)
                {
                    max2++;
                    nComodins--;
                }
                while (max1 < 3 && nComodins > 0)
                {
                    max1++;
                    nComodins--;
                }
                hiHaFull = (max2 >= 2) && (max1 >= 3);
                return hiHaFull;
            }
        }

        public bool HiHaColor
        {
            get
            {
                int nComodins = DescomposaValors()[Valor.Joker].Count;
                Dictionary<Pal, List<Carta>> dic = DescomposaPals();
                bool hihaColor = false;
                foreach (Pal p in dic.Keys)
                {
                    if (dic[p].Count + nComodins >= 5)
                        hihaColor = true;
                }
                return hihaColor;
            }
        }

        public bool HiHaEscala
        {
            get
            {

                List<Carta> llistaCartes = new List<Carta>();
                int nComodins = DescomposaValors()[Valor.Joker].Count;
                Dictionary<Pal, List<Carta>> dic = DescomposaPals();


                foreach (Pal p in dic.Keys)
                {
                    foreach (Carta c in dic[p])
                        llistaCartes.Add(c);
                }

                llistaCartes.Sort();
                int index = 0;
                bool hiHaEscala = true;
                if (llistaCartes.Count == 0)
                    return true;
                Valor v = llistaCartes[0].Valor;
                while (hiHaEscala && index < llistaCartes.Count)
                {
                    while (v < llistaCartes[index].Valor && nComodins > 0)
                    {
                        v++;
                        nComodins--;
                    }

                    hiHaEscala = v == llistaCartes[index].Valor;
                    index++;
                    v++;
                }

                return hiHaEscala;
            }
        }

        public bool HiHaEscalaDeColor
        {
            get
            {
                return HiHaEscala && HiHaColor;
            }
        }

        public bool HiHaEscalaReialDeColor
        {
            get
            {
                List<Carta> llistaCartes = new List<Carta>();
                int nComodins = DescomposaValors()[Valor.Joker].Count;
                Dictionary<Pal, List<Carta>> dic = DescomposaPals();


                foreach (Pal p in dic.Keys)
                {
                    foreach (Carta c in dic[p])
                        llistaCartes.Add(c);
                }

                llistaCartes.Sort();
                int index = 0;
                bool hiHaEscala = true;
                if (llistaCartes.Count == 0)
                    return true;
                Valor v = llistaCartes[0].Valor;
                while (hiHaEscala && index < llistaCartes.Count)
                {
                    while (v < llistaCartes[index].Valor && nComodins > 0)
                    {
                        v++;
                        nComodins--;
                    }

                    hiHaEscala = v == llistaCartes[index].Valor;
                    index++;
                    v++;
                }

                return hiHaEscala && HiHaColor && llistaCartes[0].Valor == Valor.Deu;

            }
        }

        public bool HiHaEscalaReialDeColorSenseComodins
        {
            get
            {
                List<Carta> llistaCartes = new List<Carta>();
                int nComodins = DescomposaValors()[Valor.Joker].Count;
                Dictionary<Pal, List<Carta>> dic = DescomposaPals();


                foreach (Pal p in dic.Keys)
                {
                    foreach (Carta c in dic[p])
                        llistaCartes.Add(c);
                }

                llistaCartes.Sort();
                int index = 0;
                bool hiHaEscala = true;
                if (llistaCartes.Count == 0)
                    return true;
                Valor v = llistaCartes[0].Valor;
                while (hiHaEscala && index < llistaCartes.Count)
                {
                    while (v < llistaCartes[index].Valor && nComodins > 0)
                    {
                        v++;
                        nComodins--;
                    }

                    hiHaEscala = v == llistaCartes[index].Valor;
                    index++;
                    v++;
                }

                return hiHaEscala && HiHaColor && llistaCartes[0].Valor == Valor.Deu && DescomposaValors()[Valor.Joker].Count == 0;

            }
        }
        #endregion

        /// <summary>
        /// Mira si una carta determinada està inclosa com a comodí
        /// </summary>
        /// <param name="comodins"></param>
        /// <param name="carta"></param>
        /// <returns></returns>
        private static bool Conte(List<Carta> comodins, Carta carta)
        {
            int index = 0;
            while (index < comodins.Count && carta.CompareTo(comodins[index]) != 0)
                index++;

            return index < comodins.Count;
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

