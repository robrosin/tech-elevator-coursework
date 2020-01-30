using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator
{
    class Car : IVehicle
    {
        public string Name
        {
            get
            {
                return ($"Car {HasTrailer}");
            }
        }
        bool HasTrailer { get; }
        public Car(bool hasTrailer)
        {
            HasTrailer = hasTrailer;
        }
        public double CalculateToll(int distance)
        {
            if (!HasTrailer)
            {
                return (distance * 0.020);
            }
            else
            {
                return ((distance * 0.020) + 1.00);
            }
        }
    }
}