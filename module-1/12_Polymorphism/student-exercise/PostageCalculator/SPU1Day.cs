using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator
{
    class SPU1Day : IDeliveryDriver
    {
        public string Name
        {
            get
            {
                return ($"SPU (Next Day)");
            }
        }
        public double CalculateRate(int distance, double weight)
        {
            return (weight * 0.075) * distance;
        }
    }
}