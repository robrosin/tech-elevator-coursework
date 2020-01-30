using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator
{
    class Truck : IVehicle
    {
        public string Name
        {
            get
            {
                return ($"Truck {NumberOfAxles}");
            }
        }
        int NumberOfAxles { get; }

        public Truck(int numberOfAxles)
        {
            NumberOfAxles = numberOfAxles;
        }
        public double CalculateToll(int distance)
        {
            if (NumberOfAxles <= 4)
            {
                return (distance * 0.040);
            }
            if (NumberOfAxles == 6)
            {
                return (distance * 0.045);
            }
            if (NumberOfAxles >= 8)
            {
                return (distance * 0.048);
            }
            else
            {
                return 0;
            }
        }
    }
}