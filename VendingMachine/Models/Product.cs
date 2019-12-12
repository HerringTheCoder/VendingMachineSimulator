using System;

namespace VendingMachineApp.Models
{
    class Product
    {
        public string Name { get; set; }
        private decimal _price;
        public decimal Price
        {
            get => _price;
            set
            {   //Ensures price has 1 decimal place to comply with available Coin list(eg. 1.2, 3.8, 4.80 etc.)
                if (Decimal.Round(value, 1) != value)
                    throw new FormatException("Price format not supported");
                else
                    _price = value;
            }
        }
        public int Amount { get; set; }
        public Product(string name, decimal price, int amount)
        {
            this.Name = name;
            this.Price = price;
            this.Amount = amount;
        }


    }
}
