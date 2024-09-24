// See https://aka.ms/new-console-template for more information
using System.Collections.Immutable;


Console.WriteLine("Xifrar(X)/Desxifrar(D)");
string opcio = Console.ReadLine();
if (opcio == "X")
    Xifrar();
else if (opcio == "D")
    Desxifrar();

//uemaseasusgcqtnseresitet
//aquestesunmissatgesecret
//tinc un problema de pets
//c ba siuredet pl pnnomet
static void Desxifrar()
{
    Console.WriteLine("Entra Clau");
    string clau = Console.ReadLine();
    char[] clauSorted = clau.ToArray();
    Array.Sort(clauSorted);
    Console.WriteLine("Entra text ");
    string text = Console.ReadLine();
    int colLen = text.Length / clau.Length;
    
    char[,] columnes = new char[colLen, clau.Length];

    for (int i = 0;i<clauSorted.Length;i++)
    {
        int pos = clau.IndexOf(clauSorted[i]);
        for (int j = 0;j<colLen;j++)
        {
            columnes[j,pos] = text[j];
        }
        text = text.Remove(0, colLen);
    }
    Console.WriteLine("El text desxifrat és:");
    for (int i = 0;i<columnes.GetLength(0);i++)
    {
        for (int j = 0;j<columnes.GetLength(1);j++)
        {
            Console.Write(columnes[i, j]);
        }
    }

}

static void Xifrar()
{
    Console.WriteLine("Entra Clau");
    string clau = Console.ReadLine();
    char[] clauSorted = clau.ToArray();
    Array.Sort(clauSorted);
    Console.WriteLine("Entra text a xifrar");
    string text = Console.ReadLine();
    int colLen = text.Length / clau.Length;
    char[,] columnes = new char[colLen, clau.Length];
    for (int i = 0; i < columnes.GetLength(0); i++)
    {
        for (int j = 0; j < columnes.GetLength(1); j++)
        {
            columnes[i, j] = text[j];
        }
        text = text.Remove(0, columnes.GetLength(1));
    }
    Console.WriteLine("El text xifrat és:");
    for (int i = 0; i < clauSorted.Length; i++)
    {
        int pos = clau.IndexOf(clauSorted[i]);
        for (int j = 0; j < colLen; j++)
        {
            Console.Write(columnes[j,pos]);
        }
    }
}

