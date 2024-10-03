using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Item
    {
        private string name;
        private double preu;

        public Item(string name, double preu)
        {
            this.name = name;
            this.preu = preu;
        }

        public string Name { get => name;}
        public double Preu { get => preu;}
    }
}
