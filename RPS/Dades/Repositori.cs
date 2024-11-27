using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Dades
{
    public class Repositori
    {        
        private static IRepositori? repositori = null;
        public static IRepositori ObreBDClients()
        {
            if (repositori == null)
            {
                repositori = new JugadorsXml();
            }
            return repositori;
        }    
    }
}
