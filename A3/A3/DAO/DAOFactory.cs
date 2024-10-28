using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3.DAO
{
    public class DAOFactory
    {
        public IDAO CreateMSQA(string seed)
        {
            return new MidSquareAccess(seed);
        }
    }
}
