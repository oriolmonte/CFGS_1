using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Merge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int len = 0;
            Console.Write("Introdueix una cadena de numeros separat per espais:");
            string uInput = Console.ReadLine();
            string[] sInput = uInput.Split(' ');
            foreach (string s in sInput)
            {
                len += 1;
            }
            int[] oArr = new int[len];
            int i = 0;
            foreach (string s in sInput)
            {
                oArr[i] = int.Parse(s);
                i++;
            }
            mergeSort(oArr, 0, len - 1);
            
            for(int it= 0; it<oArr.Length; it++)
            {
                if (it == oArr.Length-1)
                    Console.Write(oArr[it]);
                else
                    Console.Write(oArr[it] + " ");
            }
        } 
        static void merge(int[] arr, int origin, int mid, int end)
        {
            int n1 = mid - origin + 1;
            int n2 = end - mid;
            int[] l = new int[n1];
            int[] r = new int[n2];
            for (int i = 0; i < n1; i++) 
            {
                l[i] = arr[origin+i];
            }
            for (int j = 0; j < n2; j++)
            {
                r[j] = arr[mid + 1 + j];

            }
            //i = sub array left current pos
            //j = sub array right current pos
            //k = main array current pos
            int currLeft, currRight, currMain;
            currLeft = 0;
            currRight = 0;
            currMain = origin;
            while (currLeft < n1 && currRight < n2) 
            {
                if (l[currLeft] <= r[currRight]) 
                {
                    arr[currMain] = l[currLeft];
                    currLeft++;
                }
                else
                {
                    arr[currMain] = r[currRight];
                    currRight++;
                }
                currMain++;
            }
            // si ens acabem un dels dos arrays coloquem la resta
            while (currLeft < n1)
            {
                arr[currMain] = l[currLeft];
                currLeft++;
                currMain++;
            }
            while(currRight < n2)
            {
                arr[currMain] = r[currRight];
                currRight++;    
                currMain++;
            }
        }
        static void mergeSort(int[] array, int origin, int ending)
        {
            if (origin < ending)
            {
                int midpoint=origin+(ending-origin)/2;
                mergeSort(array,origin,midpoint);
                mergeSort(array,midpoint+1,ending);
                merge(array,origin,midpoint,ending);
            }
        }
    }
}