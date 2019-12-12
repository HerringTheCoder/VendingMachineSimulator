using System;
using System.Collections.Generic;

namespace VendingMachineApp.Models
{
    class Coin
    {
        private decimal _value;
        public decimal Value
        {
            get { return _value; }
            set
            {
                if (!ControlList.Contains(value)) //Throws 'ArgumentOutOfRange' Exception if assigned coin value is not a part of ControlList                     
                    throw new ArgumentOutOfRangeException("Coin denomination not available");
                else
                    _value = value;
            }
        }
        /*List of available coin values
         * this field is declared static, because it doesn't manage state
         * and is effectively read-only (no setter available) */
        public static List<decimal> ControlList { get; } = new List<decimal>
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
