using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

internal class Program
{
    public enum Format { Curt, Llarg };
    private static void Main(string[] args)
    {
        const string FILENAME = "SINGERS.CSV";
        Console.WriteLine("--------------------------------------------------------------------------------------\n\n");
        /// EXERCICI 1: Mostrar la informació del cantant amb l'acció InfoCantant
        string dadesCantant = "Jason Derulo,49,Man,\"Contemporary r&b, Dance, Dance-pop, Pop, R&b\",24,United States";
        Console.WriteLine("EXERCICI 1:INFORMACIÓ D'UN CANTANT A PARTIR D'UNA LINIA COM LES DEL FITXER");
        Console.WriteLine(InfoCantant(dadesCantant, Format.Llarg));
        Console.WriteLine("--------------------------------------------------------------------------------------\n\n");

        ///EXERCICI 3: Mostrar la informació de tots els cantants que comencen per una lletra (llegir tot el fitxer)
        Console.WriteLine("EXERCICI 3: INFORMACIÓ DELS CANTANTS AMB NOM QUE COMENCI PER UNA LLETRA.");
        int nCantants = LlistarCantantsQueComencenPer(FILENAME, 'E', Format.Llarg);
        Console.WriteLine($"HEM TROBAT {nCantants} CANTANTS AMB EL NOM QUE COMENÇA PER E");
        Console.WriteLine("--------------------------------------------------------------------------------------\n\n");

        //EXERCICI 5: Mostrar el % DE Woman respecte a la resta de gèneres. Cal analitzar tot el fitxer 
        double percDones = PercentatgeCantantsFemenines(FILENAME);
        Console.WriteLine("EXERCICI 5: PERCENTATGE DE Woman RESPECTE AL TOTAL DE CANTANTS");
        Console.WriteLine($"EL PERCENTATGE DE DONES RESPECTE DEL TOTAL DE CANTANTS ÉS DEL {percDones}%");
        Console.WriteLine("--------------------------------------------------------------------------------------\n\n");


        //EXERCICI 6: 
        Console.WriteLine("EXERCICI 6:GÈNERES MUSICALS DE LA CANTANT CAMILA CABELLO");
        String[] generes = GeneresMusicalsDelCantant(FILENAME, "Camila Cabello");
        Console.WriteLine("GENERES DEL CANTANT: Camila Cabello");
        if (generes!=null) foreach (String genere in generes) { Console.WriteLine(genere.Trim()); }
        Console.WriteLine("--------------------------------------------------------------------------------------\n\n");
    }

    /// <summary>
    /// A partir d'una linia que conté tota la informació d'un cantant separada per comes, 
    /// retorna el nom i el gènere del cantant (Format.Curt) i a més a més la seva nacionalitat (Format.Llarg)
    /// </summary>
    /// <param name="dadesCantant">Una linia separada per comes amb tota la info del cantant, per exemple
    /// "Jason Derulo,49,Man,"Contemporary r&b, Dance, Dance-pop, Pop, R&b",24,United States"</param>
    /// <param name="format">Llarg o Curt per si volem saber la seva nacionalitat o no</param>
    /// <returns>Retorna un String en el següent format (en cas Format.Llarg)
    ///     NOM DEL CANTANT-->Jason Derulo  GÈNERE-->Man   NACIONALITAT-->United States                               
    ///          Retorna un String en el següent format (en cas Format.Curt)
    ///     NOM DEL CANTANT-->Jason Derulo  GÈNERE-->Man
    /// </returns>
    /// PISTA : PER EXTREURE LA NACIONALITAT, PENSEU QUE ÉS L'ULTIM ELEMENT DE L'ARRAY D'STRINGS QUE HEU USAT (Propietat Length)
    public static String InfoCantant(string dadesCantant, Format format)  // EXERCICI 1:  2 Punts
    {
        string[] cantantSplit = dadesCantant.Split(',');
        StringBuilder sb = new StringBuilder();
        sb.Append($"NOM DEL CANTANT-->{cantantSplit[0]} GÈNERE-->{cantantSplit[2]}");
        if (format == Format.Llarg)
        {
            sb.Append($" NACIONALITAT-->{cantantSplit[cantantSplit.Length - 1]}");
        }
        return sb.ToString();
    }
    /// <summary>
    /// Analitza si el primer caràcter de l'string, coincideix exactament amb el caràcter inicial
    /// </summary>
    /// <param name="info">string a analitzar</param>
    /// <param name="inicial">lletra inicial</param>
    /// <returns>true si info comença per el caràcter inicial</returns>
    public static bool ComençaPer(String info, char inicial) // EXERCICI 2: 1 Punt
    {
        return info[0] == inicial;
    }
    /// <summary>
    /// Llista tots els cantants que comencen per la inicial donada. En format curt(només nom i genere) 
    /// o format llarg (nom, gènere i país)
    /// </summary>
    /// <param name="fileName">fitxer que conté tots els cantants</param>
    /// <param name="inicial">lletra inicial per la qual ha de començar els cantants del llistat</param>
    /// <param name="format">curt o llarg</param>
    /// <returns>retorna el recompte de cantants que comencen per la lletra inicial</returns>
    public static int LlistarCantantsQueComencenPer(String fileName, char inicial, Format format) // EXERCICI 3 (2,5 Punts)
    {
        int count = 0;
        StreamReader sr = new StreamReader(fileName);
        String cursor = sr.ReadLine();
        while(cursor != null)
        {
            if(ComençaPer(cursor,inicial))
            {
                count++;
                Console.WriteLine(InfoCantant(cursor,format));
            }
            cursor = sr.ReadLine();
        }
        sr.Close();
        return count;

    }

    /// <summary>
    /// A partir d'una linia amb el format
    /// María Becerra,17,Woman,"Latin, Reggaeton",17,Argentina
    /// Retorna el 3er camp . Woman en aquest exemple concret
    /// </summary>
    /// <param name="linia">linia amb info d'un cantant amb camps separats per ,</param>
    /// <returns>el 3er camp de la linia</returns>
    public static String ExtreuGenere(String linia) // EXERCICI 4: 1 Punt
    {
        string[] liniaArray = linia.Split(',');
        return liniaArray[2];
    }
    /// <summary>
    /// Calcula el percentatge de cantants del fitxer que són dones, respecte del total.
    /// Un cantant dona, és aquella que en la seva linia corresponent té al tercer camp el valor "Woman"
    /// Per exemple, respecte a les dues linies següents Dua Lipa és dona però Arcángel no és dona
    /// Arcángel,163,Man,"Latin, Reggaeton",37,Puerto Rico
    /// Dua Lipa,39,Woman,Sense dades,27,United Kingdom
    /// </summary>
    /// <param name="fileName">nom físic del fitxer que conté dades d'un cantant en cada linia</param>
    /// <returns>el percentatge de cantants que són "Woman". Si el fitxer no té cap dada, retorna -1</returns>
    public static double PercentatgeCantantsFemenines(string fileName) //EXERCICI 5: 2,5 punts
    {
        int count = 0;
        int total = 0;
        double percent;
        StreamReader sr = new StreamReader(fileName);
        string cursor = sr.ReadLine(); 
        while(cursor != null) 
        {
            if(ExtreuGenere(cursor)=="Woman")
            {
                count++;
            }
            total++;
            cursor = sr.ReadLine();
        }
        sr.Close ();
        if (total <= 0)
            percent = -1;
        else
            percent = Math.Round(((float)count / total) * 100, 1);
        return percent;
    }

    /// <summary>
    /// Cerca en el fitxer que conté tots els cantants, l'aparició del cantant amb el nom igual al paràmetre nomDelCantant
    /// I retorna tots els gèneres musicals que sap tocar el cantant.
    /// El nom del cantant apareix en el primer camp del fitxer
    /// Els gèneres musicals apareixen en el quart camp del fitxer.
    /// Per exemple, la linia del fitxer corresponent a  María Becerra canta Latín i Reggaeton
    /// María Becerra,17,Woman,"Latin, Reggaeton",17,Argentina
    /// PISTA 1: Heu de jugar amb el mètode Split separant per caràcter " o caràcter , segons convingui
    /// PISTA 2: Per separar per caràcter " heu d'especificar Split("\"") 
    /// </summary>
    /// <param name="fileName">nom físic del fitxer que conté dades d'un cantant en cada linia</param>
    /// /// <param name="nomDelCantant">Nom del cantant a cercar (primer camp del fitxer</param>
    /// <returns>un array amb tots els gèneres musicals que sap cantar el cantant. 
    /// Els gèneres musicals apareixen en el quart camp del fitxer.
    /// Per exemple, la linia del fitxer corresponent a  María Becerra canta Latín i Reggaeton
    /// María Becerra,17,Woman,"Latin, Reggaeton",17,Argentina
    /// </returns>
    public static String[] GeneresMusicalsDelCantant(string fileName, string nomDelCantant) //EXERCICI 6 : 1 punts
    {
        StreamReader sr = new StreamReader(fileName);
        string cursor = sr.ReadLine();
        List<String> generesList = new List<String>();
        bool trobat = false;
        while(!trobat && cursor != null) 
        {
            String[] cursorAux = cursor.Split("\"");
            String[] primeraMeitat = cursorAux[0].Split(',');
            if (primeraMeitat[0].Equals(nomDelCantant))
            {
                String[] generes = cursorAux[1].Split(',');
                foreach( String gene in generes) 
                {
                    generesList.Add(gene);                    
                }
                trobat = true;
            }
            else
                cursor = sr.ReadLine();
        }
        sr.Close ();
        return generesList.ToArray();
    }

}