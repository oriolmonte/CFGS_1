namespace Interficies
{
    internal class Program
    {
        private const int NPUNTS = 10;
        static void Main(string[] args)
        {
            Random rnd = new Random(); 
            List<Coordenada> llista = new List<Coordenada>();
            for (int npunts= 0; npunts < NPUNTS; npunts++ ) 
            {
                llista.Add(new Coordenada(rnd.Next(-10, 10), rnd.Next(-10, 10)));
            }
            llista.Sort();
            foreach (var l in llista) 
            {

                Console.WriteLine($"{l.Distancia}({l.X},{l.Y})");
            }
        }
    }
    public class Coordenada : IComparable<Coordenada>, IComparable
    {
        private int x;
        private int y;
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public double Distancia
        {
            get
            {
                return Math.Sqrt(X * X + Y * Y);
            }
        }
        public Coordenada(int abscises, int ordenades)
        {
            X = abscises;
            Y = ordenades;
        }
        public Coordenada() : this(0,0)
        {
            
        }
        public int CompareTo(Coordenada? other)
        {
            return Math.Sqrt(Distancia).CompareTo(Math.Sqrt(other.Distancia));
        }
        public int CompareTo(object? obj) 
        {
            if (obj != null && obj is not Coordenada) throw new ArgumentException();
            return CompareTo(obj as Coordenada);
        }
    }

    class ComparadorComparer : IComparer<Coordenada>
    {
        public int Compare(Coordenada? a, Coordenada? b)
        {
            int result = a.X - b.X;
            if (result == 0)
            {
                result = a.Y - b.Y;
            }
            return result;
        }
    }

}
