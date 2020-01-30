using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator
{
    class SPU4Day : IDeliveryDriver
    {
        public string Name
        {
            get
            {
                return ($"SPU (4-Day Ground)");
            }
        }
        public double CalculateRate(int distance, double weight)
        {
            return (weight * 0.0050) * distance;
        }
    }
}