using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace VendingMachineApp.Models
{
    class VendingMachine : BaseModel, IWallet
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public decimal Credit
        {
            get { return Wallet.Sum(item => item.Value); } //Linq returning a sum of money in virtual wallet           
        }
        //Virtual wallet containing ready-to-return set of coins
        public List<Coin> Wallet { get; set; } = new List<Coin>();

        private string _log;
        public string Log
        {
            get => _log;
            set
            {
                _log = value;
                OnPropertyChanged("Log");
            }
        }
        public VendingMachine()
        {
            Products.Add(new Product("Cola", 2.5m, 10));
            Products.Add(new Product("Water", 1.5m, 15));
            Products.Add(new Product("Sprite", 2.0m, 10));
            Products.Add(new Product("Fanta", 1.8m, 20));
        }
        //Finds a selected product modifies its amount and detracts its price from available credit
        public void SellProduct(string productName)
        {
            Product obj = Products.First(item => item.Name == productName);
            if (obj != null && obj.Amount > 0 && Credit >= obj.Price)
            {
                obj.Amount--;
                CalculateRemainder(obj.Price);
                /* Choose one of the two lines below to decide if you want to return money after each purchase */
                //ResetCredit("Sold " + obj.Name + " for: " + obj.Price + "zł\nAmount left: " + obj.Amount + "\n");
                Log = "Sold " + obj.Name + " for: " + obj.Price + "zł\nAmount left: " + obj.Amount + "\n";               
            }
            else if (Credit < obj.Price && obj.Amount > 0)
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
            Wallet.Clear();
            foreach (decimal coinType in Coin.ControlList) //This loop iterates over the list of available (statically pre-defined in Coin class) denominations
            {
                int result = Math.DivRem(credit, Convert.ToInt32(coinType * 100), out int remainder);
                Debug.WriteLine("Result is equal: {0}\n Remainder is equal: {1}", result, remainder);
                if (remainder > 0)
                {
                    for (int i = 0; i < result; i++)
                    {
                        this.InsertCoin(coinType);
                        credit -= Convert.ToInt32(coinType * 100);
                    }
                }
                else if (remainder == 0)
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
            Log = (coinValue < 1.0m) ? "Added " + Convert.ToInt32(coinValue * 100) + "gr" : "Added " + Convert.ToInt32(coinValue) + "zł";
        }
        //Simulates returning credit by removing Coins from virtual wallet and listing them for user // TODO: sending coins to user's wallet
        public void ResetCredit(string input="")
        {
            string summary = input+"Returned coins: \n";
            foreach (Coin item in Wallet)
            {   
                summary += (item.Value < 1.0m) ? Convert.ToInt32(100 * item.Value) + "gr, " : Convert.ToInt32(item.Value) + "zł, ";  //Converting to int is safe, because both input numbers will always have .0m format          
            }
            Wallet.Clear();
            Log = summary;
        }
    }
}
