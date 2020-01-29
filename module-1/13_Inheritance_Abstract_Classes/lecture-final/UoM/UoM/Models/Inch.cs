using System;
using System.Collections.Generic;
using System.Text;

namespace UoM.Models
{
    public class Inch : Length
    {
        public override double ConversionFactor
        {
            get
            {
                return 2.54;
            }
        }

        public Inch(double amount) : base("inch", "inches", amount) { }
    }
}
