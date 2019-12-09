using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineApp.Models
{
    class Denomination
    {
        private double _value;
        public double Value {
            get { return _value; }
            set {
                if (!ControlList.Contains(value))
                    throw new NotSupportedException();
                else
                    _value = value;
            }
                }
        public List<double> ControlList { get; private set; } = new List<double>
             {
                0.1,
                0.2,
                0.5,
                1.0,
                2.0,
                5.0
            }; 
        public Denomination(double val)
        {
            this.Value = val;
        }

    }
}
