namespace ex7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Random random = new Random();
            int numA, numB, nota=0;
            //suma
            numA = random.Next(2, 101);
            numB = random.Next(2, 101);
            Console.Write(numA + "+" + numB + " = ");
            int suma = int.Parse(Console.ReadLine());
            int sumaR = numA + numB;
            //Comparem input amb resultat
            if (suma == sumaR)
            {
                nota++;
            }
            numA = random.Next(2, 101);
            numB = random.Next(2, 101);
            Console.Write(numA + "-" + numB + " = ");
            int resta = int.Parse(Console.ReadLine());
            int restaR = numA - numB;
            if (resta == restaR)
            {
                nota++;
            }
            numA = random.Next(2, 101);
            numB = random.Next(2, 101);
            Console.Write(numA + "*" + numB + " = ");
            int mult = int.Parse(Console.ReadLine());
            int multR = numA * numB;
            if (mult == multR)
            {
                nota++;
            }
            numA = random.Next(2, 101);
            numB = random.Next(2, 101);
            Console.Write(numA + "/" + numB + " = ");
            int div = int.Parse(Console.ReadLine());
            int divR = numA / numB;
            if (div == divR)
            {
                nota++;
            }
            switch (nota)
            {
                case 0:
                    Console.WriteLine("E(Very Poor");
                    break;
                case 1:
                    Console.WriteLine("F(Fail)");
                    break;
                case 2:
                    Console.WriteLine("C(Pass)");
                    break;
                case 3:
                    Console.WriteLine("B(Good)");
                    break;
                case 4:
                    Console.WriteLine("A(Very Good)");
                    break;
            }
        }
    }
}