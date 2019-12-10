using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineApp.Models
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }       
        public int Amount { get; set; }

        public Product(string name, double price, int amount)
        {
            this.Name = name;
            this.Price = price;
            this.Amount = amount;
        }
    }
}
