using System;
using System.Xml.XPath;

namespace EficienciaDL;

internal class EficienciaDL
{
    static void Main()
    {
        Console.WriteLine($"Mida;Cerca seqüencial;Cerca dicotòmica");
        Random r = new Random();
        for(int i = 1000; i<100000;i+=500)
        {
            int[] ints = new int[i];
            int opSequencial = 0;
            int opDicotomica = 0;
            for(int j = 1; j<i;j++)
            {
                ints[j]=j*2;
            }
            for(int k=0; k<i/4;k++)
            {
                int element = r.Next(2,ints.Length*2+1);
                if(element%2!=0) element++;
                opSequencial+=CercaSequencial(element,ints);
                opDicotomica+=CercaDicotomica(element,ints);
            }
            Console.WriteLine($"{i};{opSequencial/(i/4)};{opDicotomica/(i/4)}");
        }
    }
    public static int CercaSequencial(int element, int[] array)
    {
        int i = 0;
        bool trobat = false;
        while(!trobat && i<array.Length)
        {
            if(element>array[i])
                i++;
            else
                trobat=true;
        }
        return i;
    }
    public static int CercaDicotomica(int element, int[] array)
    {
        return CercaDicotomica(element, array, 0,array.Length/2+1);
    }
    public static int CercaDicotomica(int element, int[] array, int inici, int final)
    {
        int nombreOperacions = 0;
        int mig = (inici+final)/2;
        if(inici==final)
        {
            nombreOperacions+=1;
        }
        else if(element<array[mig])
        {
            nombreOperacions+=CercaDicotomica(element,array,inici,mig);
            nombreOperacions+=1;
        }
        else if(element>array[mig])
        {
            nombreOperacions+=CercaDicotomica(element,array,mig+1,final);                        
            nombreOperacions+=1;
        }
        return nombreOperacions;
    } 

}