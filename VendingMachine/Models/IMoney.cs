using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineApp.Models
{
    interface IMoney
    {
        List<Denomination> Money {get;set;}
    }
}
