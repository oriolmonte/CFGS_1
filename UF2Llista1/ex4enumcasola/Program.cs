namespace ex4enumcasola
{
    internal class Program
    {
        public enum DiaSetmana
        {
            Dilluns,
            Dimarts,
            Dimecres,
            Dijous,
            Divendres,
            Dissabte,
            Diumenge
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 7; i++) 
            {
                Console.WriteLine(NotWeekend((DiaSetmana)i));
            }
        }
        public static bool NotWeekend(DiaSetmana dia)
        {
            bool result;
            if(dia<DiaSetmana.Dissabte)
            { 
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}