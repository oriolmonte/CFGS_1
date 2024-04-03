using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MontyPizza
{
    public class Supplier
    {
        private string companyName;
        private string adress;
        private string nif;
        private List<Ingredient> ingredients;

        public Ingredient Ingredient
        {
            get => default;
            set
            {
            }
        }
    }
}