using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineApp.Models
{
    class Coin
    {
        private decimal _value;
        public decimal Value {
            get { return _value; }
            set {
                if (!ControlList.Contains(value))
                    throw new NotSupportedException();
                else
                    _value = value;
            }
                }
        public static List<decimal> ControlList { get; private set; } = new List<decimal>
             {
                5.0m,
                2.0m,
                1.0m,
                0.5m,
                0.2m,
                0.1m
            }; 
        public Coin(decimal val)
        {
            this.Value = val;
        }

    }
}
