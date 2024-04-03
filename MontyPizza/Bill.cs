using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MontyPizza
{
    public class Bill
    {
        private Restaurant restaurantInfo;
        private int billId;
        private DateTime date;
        private List<Pizza> pizzas;

        public Restaurant Restaurant
        {
            get => default;
            set
            {
            }
        }

        public Pizza Pizza
        {
            get => default;
            set
            {
            }
        }
    }
}