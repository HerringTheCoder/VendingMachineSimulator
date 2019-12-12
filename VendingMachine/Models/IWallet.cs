using System.Collections.Generic;

namespace VendingMachineApp.Models
{
    interface IWallet
    {
        List<Coin> Wallet { get; set; }
        public void InsertCoin(decimal SelectedCoin);
    }
}
