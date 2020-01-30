using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator
{
    class SPU2Day : IDeliveryDriver
    {
        public string Name
        {
            get
            {
                return ($"SPU (2-Day Business)");
            }
        }
        public double CalculateRate(int distance, double weight)
        {
            return (weight * 0.050) * distance;
        }
    }
}
