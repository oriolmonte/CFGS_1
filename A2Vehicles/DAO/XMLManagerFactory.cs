﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2Vehicles
{
    public class XMLManagerFactory
    {
        public IXMLManager CreateXMLImpl()
        {
            return new XMLManagerImpl();
        }
    }
}
