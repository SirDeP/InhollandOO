using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaConsole
{
    public class Pizza
    {
        private string toppings;
        private int diameter;
        private double price;

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value >= 0)
                {
                    price = value;
                }
                else
                    Console.WriteLine("Price cannot be negative");
            }
        }
        public int Diameter
        {
            get
            {
                return diameter;
            }
            set
            {
                if (value >= 0)
                    diameter = value;
                else
                    Console.WriteLine("Diameter cannot be negative");
            }
        }
        public string Toppings
        {
            get
            {
                return toppings;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    Console.WriteLine("Toppings cannot be empty");
                else
                    toppings = value;
                    
            }
        }
    }
}
