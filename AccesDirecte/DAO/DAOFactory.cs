using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesDirecte.DAO
{
    public class DAOFactory
    {
        public IDAO CreateDAO()
        {
            return new MidSquareAccess();
        }
    }
}
