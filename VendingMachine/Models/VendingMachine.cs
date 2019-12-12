using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace VendingMachineApp.Models 
{
    class VendingMachine : BaseModel, IWallet
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public decimal Credit
        {
            get { return Wallet.Sum(item => item.Value); } //Linq returning a sum of money in virtual wallet           
        }

        //Virtual wallet containing money inserted by machine user
        public List<Coin> Wallet { get; set; } = new List<Coin>();

        private string _log;
        public string Log
        {
            get => _log;
            set {
                _log = value;
                OnPropertyChanged("Log");
            }
        }
        public VendingMachine()
        {
            Products.Add(new Product("Cola", 2.5m, 10));
            Products.Add(new Product("Water", 1.5m, 15));
            Products.Add(new Product("Sprite", 2.0m, 10));
            Products.Add(new Product("Fanta", 2.0m, 10));

        }
        //Finds a selected product modifies its amount and detracts its price from available credit
        public void SellProduct(string productName)
        {
            Product obj = Products.First(item => item.Name == productName);
            if (obj != null && obj.Amount > 0 && Credit >= obj.Price)
            {
                obj.Amount--;
                CalculateRemainder(obj.Price);
                Log = "Sold " + obj.Name + " for: " + obj.Price + "zł\nAmount left: " + obj.Amount + "\n";
                Debug.WriteLine("Credit after recalculation equals: {0}", Credit);
            }
            else if(Credit<obj.Price && obj.Amount>0)
            {
                Log = "Insufficient funds!";
            }
            else
            Log = "Product unavailable!";

        }
        //Reorganizes virtual wallet to prepare for returning change to user
        public void CalculateRemainder(decimal price)
        {
            int credit = Convert.ToInt32((Credit - price) * 100);
            Debug.WriteLine("Credit after subtraction equals: {0}", credit);
            var controlList = Coin.ControlList; //Creates a copy of coin control list to determine which coins are available
            Wallet.Clear();
            foreach (decimal coinType in controlList)
            {
                int result = Math.DivRem(credit, Convert.ToInt32(coinType * 100), out int remainder);
                Debug.WriteLine("Result is equal: {0}\n Remainder is equal: {1}", result, remainder);
                if (remainder > 0)
                {
                    for (int i = 0; i < result; i++)
                    {
                        this.InsertCoin(coinType);
                        credit -= Convert.ToInt32(coinType*100);
                    }
                }
                else if (remainder==0)
                {
                    for (int i = 0; i < result; i++)
                    {
                        this.InsertCoin(coinType);
                    }
                    return;
                }
            }                        
        }
        //Inserts a coin value, which is checked in coin class for integrity and adds it to the wallet
        public void InsertCoin(decimal coinValue)
        {
            Wallet.Add(new Coin(coinValue));
        }
        //Simulates returning credit by removing Coins from virtual wallet and listing them for user
        public void ResetCredit()
        {
            string summary = "Returned coins: \n";
            foreach (Coin item in Wallet)
            {                
                    summary += (item.Value < 1.0m) ? Convert.ToInt32(item.Value* 100) + "gr, " : Convert.ToInt32(item.Value) + "zł, ";               
            }
            Wallet.Clear();
            Log = summary;
        }        
    }
}
