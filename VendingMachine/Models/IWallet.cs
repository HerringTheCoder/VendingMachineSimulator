using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineApp.Models
{
    interface IWallet
    {
        List<Coin> Wallet {get;set;}
        public void InsertCoin(decimal SelectedCoin);       
    }
}
