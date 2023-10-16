namespace charmander
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char c = Convert.ToChar(Console.ReadLine());
            //double angle = Convert.ToDouble(Console.ReadLine());
            bool b;
            /* a)
            if (c >= 'a' && c <= 'z')
            {
                b = true;
            }
            */
            /* b)
            if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
            {
                b = true;
            }
            */
            /* c)
            if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
            {
                b = true;
            }
            */ 
            /* d)
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
            {
                b = true;
            }
            */
            /* e)
            if (!((c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')))
            {
                b = true;
            }
            */
            /* f)
            if (c >= '0' && c <= '9')
            {
                b = true;
            }
            */
            /* g)
            if (angle > 90 && angle < 180)
            {
                b = true;
            }
            */
            if (c >= 'a' && c <= 'z')
            {
                Console.WriteLine("minuscula");
            }
            else if(c >= 'A' && c <= 'Z')
            {
                Console.WriteLine("majuscula");
            }
            else
            {
                Console.WriteLine("no es una lletra");
            }
        }
    }
}