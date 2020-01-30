using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator
{
    class Tank : IVehicle
    {
        public string Name
        {
            get
            {
                return ($"Tank");
            }
        }
        public bool HasTrailer
        {
            get
            {
                return false;
            }
        }
        public double CalculateToll(int distance)
        {
            return (distance * 0.0);
        }
    }
}
