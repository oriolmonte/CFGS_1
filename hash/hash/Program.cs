namespace hash
{
    using System;

    class Program
    {
        static int Hash(string input)
        {
            int suma = 0;
            foreach (char c in input)
            {
                suma += (int)c;
            }
            return suma;
        }

        static void Decode(string hashcode)
        {
            int targetHash = int.Parse(hashcode);
            for (int i = 'A'; i <= 'Z'; i++)
            {
                for (int j = 'A'; j <= 'Z'; j++)
                {
                    for (int r = 'A'; r <= 'Z'; r++)
                    {
                        string result = ((char)i).ToString() + ((char)j).ToString() + ((char)r).ToString();
                        int hashstring = Hash(result);
                        if (hashstring == targetHash)
                        {
                            Console.WriteLine(result);
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter hash code:");
            string input = Console.ReadLine();
            Decode(input);
        }
    }

}