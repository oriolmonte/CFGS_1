namespace ex12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool existeix = false;
            string cursor;
            int any=0;
            StreamReader sr = new StreamReader("anys.txt");
            cursor = sr.ReadLine();
            while (cursor != null && !existeix) 
            {

                any = int.Parse(cursor);
                if (IsHuluku(any) && IsBulukulu(any))
                {
                    existeix = true;
                }
                cursor = sr.ReadLine();
            }
            if (existeix)
                Console.WriteLine($"Hi ha un any que compleix les condicions. És l'any {any}.");
            else
                Console.WriteLine("No existeix dins el document");


        }
        public static bool IsLeap(int any)
        {
            return (any % 4 == 0 && any % 100 != 0) || any % 400 == 0;
        }
        public static bool IsHuluku(int any)
        {
            return any%15==0;
        }

        public static bool IsBulukulu(int any) 
        {
            return IsLeap(any) && any % 55 == 0;
        }
    }
}