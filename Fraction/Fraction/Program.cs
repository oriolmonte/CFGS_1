namespace Fraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fraction f = new Fraction(1,3,'+');
            Fraction f2 = new Fraction(4,2,'+');
            Console.WriteLine(f2.Denominator);
            Console.Write("f: ");
            Console.WriteLine(f);
            Console.Write("f2: ");
            Console.WriteLine(f2.ToString());
            Console.Write("Equivalents: ");
            bool eq = Fraction.Equivalents(f, f2);
            Console.WriteLine(eq);
            Fraction fresult = Fraction.Add(f, f2);
            Console.Write("Add: ");
            Console.WriteLine(fresult.ToString());
            fresult = Fraction.Substract(f, f2);
            Console.Write("Substract: ");
            Console.WriteLine(fresult.ToString());
            fresult = Fraction.Multiply(f, f2);
            Console.Write("Multiply ");
            Console.WriteLine(fresult.ToString());
            fresult = Fraction.Divide(f, f2);
            Console.Write("Divide: ");
            Console.WriteLine(fresult.ToString());
            fresult = f + f2;
            Console.Write("f+f2: ");
            Console.WriteLine(fresult.ToString());
            fresult = f-f2;
            Console.Write("f-f2: ");
            Console.WriteLine(fresult.ToString());
            Console.Write("-f: ");
            fresult = -f;
            Console.WriteLine(fresult.ToString());
            Console.Write("f/f2: ");
            fresult = f/f2;
            Console.WriteLine(fresult.ToString());
            Console.Write("f2 real value: ");
            Console.WriteLine(f2.RealValue);
            Console.Write("f == f2: ");
            Console.WriteLine(f == f2);
            Console.Write("f != f2: ");
            Console.WriteLine(f != f2);
            Console.Write("(double)f: ");
            Console.WriteLine((double)f);
            fresult = f++;
            Console.WriteLine(fresult);
            Fraction fInt = -100;
            Console.Write("Fraction fInt = -100: ");
            Console.WriteLine(fInt.ToString());
            Console.WriteLine("Numerador i denominador");
            Console.WriteLine(fInt.Numerator);
            Console.WriteLine(fInt.Denominator);
        }
    }
}