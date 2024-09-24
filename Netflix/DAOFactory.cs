using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix
{
    public class DAOFactory
    {
        public IDAO CreateNetflixImpl()
        {
            return new NetflixImpl();
        }
    }
}
