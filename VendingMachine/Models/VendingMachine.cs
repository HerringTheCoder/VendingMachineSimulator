using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachineApp.Models
{
    class VendingMachine : IMoney
    {
        public List<Product> Products { get; private set; } = new List<Product>();

        public double Credit { get; set; } = 0;               
           
        public List<Denomination> Money { get; set; }

        public VendingMachine()
         {
            Products.Add(new Product("Cola", 2.5, 10));
            Products.Add(new Product("Water", 1.5, 15));
            Products.Add(new Product("Sprite", 2.0, 10));
            Products.Add(new Product("Fanta", 2.0, 10));         
           
         }
    }
}
