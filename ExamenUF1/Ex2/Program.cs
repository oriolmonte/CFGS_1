namespace Ex2
{
    internal class Program
    {
        public const int ALTA = 41;
        public const int BAIXA = -10;
        public const string FILENAME = "temperatures.txt";
        static void Main(string[] args)
        {
            string cursor;
            double temp;
            bool alerta = false;
            int contAlt = 0, contBaix = 0;
            StreamReader sr = new StreamReader(FILENAME);
            cursor = sr.ReadLine();
            while (cursor != null && !alerta) 
            {
                temp = Convert.ToDouble(cursor);
                if (temp>ALTA)
                    contAlt++;
                if (temp < BAIXA) 
                    contBaix++;
                if(contAlt>3 && contBaix>2)
                    alerta = true;
                else
                    cursor = sr.ReadLine();
            }
            sr.Close();
            if (alerta)
                Console.WriteLine("HI HA ALERTA DE CANVI CLIMÀTIC");
            else
                Console.WriteLine("NO HI HA ALERTA DE CANVI CLIMÀTIC");
        }
    }
}