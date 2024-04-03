using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MontyPizza
{
    public class Pizza
    {
        private int pizzaId;
        private List<Ingredient> ingredientList;
        private string name;
        private DateTime expirationDate;

        public Ingredient Ingredient
        {
            get => default;
            set
            {
            }
        }
    }
}