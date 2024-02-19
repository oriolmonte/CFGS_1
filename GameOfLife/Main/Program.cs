namespace Main
{
    internal class Program
    {
        public const int WIDTH = 25;
        public const int HEIGHT = 50;
        public const int PERCENT_ON = 30;
        public const ConsoleColor COLORFONS = ConsoleColor.DarkGray;
        public const ConsoleColor COLOR_EMPTY = ConsoleColor.Gray;
        public const ConsoleColor COLOR_FULL = ConsoleColor.Yellow;
        enum EstatCasella
        {
            Empty,
            Full
        }
        static void Main(string[] args)
        {
            ConsoleKey tecla;
            //EstatCasella[][] taulell;
            //taulell = new EstatCasella[HEIGHT][];
            //for (int i = 0; i<HEIGHT; i++) 
            //{
            //    taulell[posicio] = new EstatCasella[WIDTH];
            //}
            EstatCasella[,] tauler = new EstatCasella[HEIGHT, WIDTH];
            StartUp(tauler);
            Draw(tauler);
            tecla = Console.ReadKey().Key;
            while (tecla != ConsoleKey.D0)
            {
                NextGen(tauler);
                Draw(tauler);
                tecla = Console.ReadKey().Key;
            }

        }
        /// <summary>
        /// Crea el tauler amb caselles aleatoriament buides i plenes
        /// </summary>
        /// <param name="tauler"></param>
        private static void StartUp(EstatCasella[,] tauler)
        {
            Random random = new Random();
            for (int i = 0; i < HEIGHT; i++) 
            {
                for(int j = 0;j<WIDTH;j++)
                {
                    if (random.Next(100)<PERCENT_ON)
                    {
                        tauler[i, j] = EstatCasella.Full;
                    }
                    else
                    {
                        tauler[i,j] = EstatCasella.Empty;
                    }
                }
            }
        }
        /// <summary>
        /// Pinta el tauler a la consola
        /// </summary>
        /// <param name="tauler"></param>
        private static void Draw(EstatCasella[,] tauler)
        {
            Console.BackgroundColor = COLORFONS;
            Console.Clear();
            for (int i = 0;i < HEIGHT;i++) 
            {
                for(int j = 0;j<WIDTH;j++)
                {
                    if (tauler[i, j] == EstatCasella.Full)
                    {

                        Console.ForegroundColor = COLOR_FULL;
                    }
                    else
                    {
                        Console.ForegroundColor = COLOR_EMPTY;
                    }
                    Console.SetCursorPosition(i, j);
                    Console.Write("█");
                }
            }
        }
        private static void NextGen(EstatCasella[,] tauler)
        {
            //Taula Auxiliar
            EstatCasella[][] novaGeneracio = new EstatCasella[HEIGHT][];
            for (int i= 0; i<HEIGHT;i++)
            {
                novaGeneracio[i] = new EstatCasella[WIDTH];
            }
            
            for(int i= 0;i<HEIGHT;i++)
            {
                for(int j= 0;j<WIDTH;j++)
                {
                    int numeroDeVeins = ComptaVeins(i, j, tauler);
                    if (tauler[i,j]==EstatCasella.Full)
                    {
                        if(numeroDeVeins==2||numeroDeVeins==3)
                        {
                            novaGeneracio[i][j] = EstatCasella.Full;
                        }
                        else
                        {
                            novaGeneracio[i][j] = EstatCasella.Empty;
                        }
                    }
                    else
                    {
                        if (numeroDeVeins == 3)
                            novaGeneracio[i][j] = EstatCasella.Full;
                        else
                            novaGeneracio[i][j] = EstatCasella.Empty;
                    }
                }
            }
            CopiaTauler(novaGeneracio, tauler);
        }

        private static void CopiaTauler(EstatCasella[][] origen, EstatCasella[,] destinacio)
        {
            for (int i=0;i<HEIGHT;i++) 
            {
                for(int j=0;j<WIDTH;j++)
                {
                    destinacio[i,j] = origen[i][j];
                }
            }
        }

        /// <summary>
        /// Quants veins vius te cada casella
        /// </summary>
        /// <param name="fila"></param>
        /// <param name="columna"></param>
        /// <param name="tauler"></param>
        /// <returns></returns>
        private static int ComptaVeins(int fila, int columna, EstatCasella[,] tauler)
        {
            int veins = 0;

            veins = veins + NVeinsALaPosicio(fila - 1, columna - 1, tauler);
            veins = veins + NVeinsALaPosicio(fila - 1, columna, tauler);
            veins = veins + NVeinsALaPosicio(fila - 1, columna + 1, tauler);
            veins = veins + NVeinsALaPosicio(fila, columna - 1, tauler);
            veins = veins + NVeinsALaPosicio(fila, columna + 1, tauler);
            veins = veins + NVeinsALaPosicio(fila + 1, columna - 1, tauler);
            veins = veins + NVeinsALaPosicio(fila + 1, columna, tauler);
            veins = veins + NVeinsALaPosicio(fila + 1, columna + 1, tauler);


            return veins;
        }

        private static int NVeinsALaPosicio(int v1, int v2, EstatCasella[,] tauler)
        {
            int veins = 0;
            if(v1>0 && v2 >0)
            {
                if (v1 < HEIGHT && v2 < WIDTH && tauler[v1, v2] == EstatCasella.Full )
                    veins = 1;
            }
            return veins;
        }
    }
}