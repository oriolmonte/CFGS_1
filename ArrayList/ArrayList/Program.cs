namespace ArrayList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Constructor
            TaulaLlista taulaLlista = new TaulaLlista(5);
            //Afegir
            taulaLlista.Afegeix(1);
            taulaLlista.Afegeix(2);
            TaulaLlista taulaLlista2 = new TaulaLlista(5);
            //Equals error
            Console.WriteLine(taulaLlista.Equals(taulaLlista2));
            Console.WriteLine(taulaLlista.Equals("Pupu"));
            taulaLlista2.Afegeix(1);
            taulaLlista2.Afegeix(2);
            //Equals correcte
            Console.WriteLine(taulaLlista.Equals(taulaLlista2));
            taulaLlista.Afegeix(3);
            taulaLlista.Afegeix(4);
            taulaLlista.Afegeix(5);
            //Contains
            Console.WriteLine(taulaLlista.Conte(1));
            Console.WriteLine(taulaLlista.Conte(60));
            //Copia
            TaulaLlista taulaCopia = new TaulaLlista(taulaLlista);
            Console.WriteLine(taulaCopia.ToString());
            //AfegeixRang
            taulaLlista.AfegeixRang(new object[] { 5, 6, 7, 8 });
            //Invertir
            taulaLlista.Inverteix();
            //this[] set i get
            taulaLlista[0] = 1;
            Console.WriteLine(taulaLlista[0]);
            //Indexof i lastindexof
            int index = taulaLlista.IndexDe(5);
            int index2 = taulaLlista.ultimIndexDe(1);
            Console.WriteLine(index);
            Console.WriteLine(index2);
            //ToString()
            Console.WriteLine(taulaLlista.ToString());
            //ToArray()
            object[] taulaLlistaArray = taulaLlista.ToArray();
            foreach (object obj in taulaLlistaArray)
            {
                Console.Write($"{obj.ToString()} ");
            }
            Console.WriteLine();
            //Insereix
            taulaLlista.Insereix(2, 3);
            Console.WriteLine(taulaLlista.ToString());
            //Elimina A
            taulaLlista.EliminaAt(2);
            Console.WriteLine(taulaLlista.ToString());
            //Elimina
            Console.WriteLine(taulaLlista.Elimina(1));
            Console.WriteLine(taulaLlista.ToString());

            //TaulaLlista tAndromines = new TaulaLlista(20);
            //Random r = new Random();
            //for (int i = 0; i < tAndromines.Capacitat; i++) 
            //{
            //    if(r.Next(2)==0)
            //    {
            //        object o = new Cercle(i,i,i*2,i*3);
            //        tAndromines.Afegeix(o);
            //    }
            //    else
            //    {
            //        object o = new Article(i, $"ARTICLE - {i}", i);
            //        tAndromines.Afegeix(o);
            //    }
            //}
            //for(int i = 0;i < tAndromines.NElems;i++) 
            //{
            //    if (tAndromines[i] is Article)
            //    {
            //        Article atzarA = (Article)tAndromines[i];
            //        atzarA.IncrementarPreu(2);
            //        Console.WriteLine($"Codi:{atzarA.Codi} | Preu:{atzarA.Preu} Euros | Descripcio: {atzarA.Desc}");
            //    }
            //    else if (tAndromines[i] is Cercle)
            //    {
            //        Cercle atzarC = (Cercle)tAndromines[i];
            //        Console.WriteLine($"Origen ({atzarC.X},{atzarC.Y}) | Preu = {atzarC.Preu} Euros");
            //    }
            //}

        }
    }
}