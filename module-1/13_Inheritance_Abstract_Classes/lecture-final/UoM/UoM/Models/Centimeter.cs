using System;
using System.Collections.Generic;
using System.Text;

namespace UoM.Models
{
    public class Centimeter : Length
    {
        public override double ConversionFactor
        {
            get
            {
                return 1;
            }
        }

        public Centimeter(double amt) : base("centimeter", "centimeters", amt) { }

    }
}
