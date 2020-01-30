using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator
{
    class FexEd : IDeliveryDriver
    {
        public string Name
        {
            get
            {
                return ($"FexEd");
            }
        }
        double rate = 20.00;
        public double CalculateRate(int distance, double weight)
        {
            if (distance > 500)
            {
                return rate + 5.00;
            }
            if (weight > 48)
            {
                return rate + 3.00;
            }
            return rate;
        }
    }
}
