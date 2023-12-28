namespace ex8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Average from file:{AverageFromFile("file.txt")}");

        }
        public static double AverageFromFile(string sr)
        {
            StreamReader srReader = new StreamReader(sr);
            int contador = 0, total = 0;
            string cursor = srReader.ReadLine();
            while(cursor != null)
            {
                contador++;
                total += int.Parse(cursor);
                cursor = srReader.ReadLine();
            }
            srReader.Close();
            return Math.Round((double)total/contador,2);
        }
    }
}