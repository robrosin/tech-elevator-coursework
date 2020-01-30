using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator
{
    class PostalService2 : IDeliveryDriver
    {
        public string Name
        {
            get
            {
                return ($"Postal Service (2nd Class)");
            }
        }
        public double CalculateRate(int distance, double weight)
        {
            if (weight <= 2)
            {
                return (distance * 0.0035);
            }
            else if ((weight > 2) && (weight <= 8))
            {
                return (distance * 0.0040);
            }
            else if ((weight > 8) && (weight <= 15))
            {
                return (distance * 0.0047);
            }
            else if ((weight > 15) && (weight <= 48))
            {
                return (distance * 0.0195);
            }
            else if ((weight > 48) && (weight <= 128))
            {
                return (distance * 0.0450);
            }
            else
            {
                return (distance * .500);

            }
        }
    }
}
