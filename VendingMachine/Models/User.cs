using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineApp.Models
{
    class User : IWallet 
    {
        public List<Coin> Money { get; set; }
        public List<Coin> Wallet { get; set; }      
        public void InsertCoin(decimal coinValue)
        {
            Wallet.Add(new Coin(coinValue));
        }
    }
}
