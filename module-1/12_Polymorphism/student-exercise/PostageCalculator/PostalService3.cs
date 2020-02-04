﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator
{
    class PostalService3 : IDeliveryDriver
    {
        public string Name
        {
            get
            {
                return ($"Postal Service (3rd Class)");
            }
        }
        public double CalculateRate(int distance, double weight)
        {
            if (weight <= 2)
            {
                return (distance * 0.020);
            }
            else if ((weight > 2) && (weight <= 8))
            {
                return (distance * 0.022);
            }
            else if ((weight > 8) && (weight <= 15))
            {
                return (distance * 0.024);
            }
            else if ((weight > 15) && (weight <= 48))
            {
                return (distance * 0.0150);
            }
            else if ((weight > 48) && (weight <= 128))
            {
                return (distance * 0.0160);
            }
            else
            {
                return (distance * .0170);

            }
        }
    }
}