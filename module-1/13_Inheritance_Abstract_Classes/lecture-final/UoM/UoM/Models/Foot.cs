using System;
using System.Collections.Generic;
using System.Text;

namespace UoM.Models
{
    public class Foot : Length
    {
        public override double ConversionFactor => 12 * 2.54;

        public Foot(double amt) : base("foot", "feet", amt) { }
    }
}
