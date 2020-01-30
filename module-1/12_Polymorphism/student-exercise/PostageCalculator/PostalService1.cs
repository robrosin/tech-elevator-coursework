using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator
{
    class PostalService1 : IDeliveryDriver
    {
        public string Name
        {
            get
            {
                return ($"Postal Service (1st Class)");
            }
        }
        public double CalculateRate(int distance, double weight)
        {
            if (weight <= 2)
            {
                return (distance * 0.035);
            }
            else if ((weight > 2) && (weight <= 8))
            {
                return (distance * 0.040);
            }
            else if ((weight > 8) && (weight <= 15))
            {
                return (distance * 0.047);
            }
            else if ((weight > 15) && (weight <= 48))
            {
                return (distance * 0.195);
            }
            else if ((weight > 48) && (weight <= 128))
            {
                return (distance * 0.450);
            }
            else
            {
                return (distance * .500);

            }
        }
    }
}