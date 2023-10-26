namespace ex1b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int primer, cursorInt, count;
            count = 1;
            Console.WriteLine("Entra el primer número:");
            primer = int.Parse(Console.ReadLine());
            Console.WriteLine("Entra el següent:");
            cursorInt = int.Parse(Console.ReadLine());
            while (primer!=cursorInt && cursorInt!=-9999)
            {
                Console.WriteLine("Entra el següent:");
                cursorInt = int.Parse(Console.ReadLine());
                count++;
            }
            if (cursorInt == -9999)
                Console.WriteLine($"{primer} no s'ha repetit");
            else 
                Console.WriteLine($"{primer} s'ha repetit a la posició {count}");
            
        }
    }
}