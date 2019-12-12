using System;
using System.Collections.Generic;

namespace VendingMachineApp.Models
{
    /*This is an example of not implemented class, that could use (in practical appliance) IWallet interface.*/
    class User : IWallet
    {
        public List<Coin> Money { get; set; }
        public List<Coin> Wallet { get; set; }
        public void InsertCoin(decimal coinValue)
        {
            Wallet.Add(new Coin(coinValue));
        }
        public User()
        {
            throw new NotImplementedException("User handling is not yet supported");
        }
    }
}
