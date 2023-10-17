namespace ex8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Any?");
            int any = Convert.ToInt32(Console.ReadLine());
            if((any%4==0 && any%100 !=0) || any%400 ==0)
            {
                Console.WriteLine("Traspas");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}