using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineApp.Models
{
    class Wallet : IMoney
    {
        public List<Denomination> Money { get; set; }

        public Wallet()
        {

        }
    }
}
