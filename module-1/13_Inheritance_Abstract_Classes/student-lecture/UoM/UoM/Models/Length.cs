using System;
using System.Collections.Generic;
using System.Text;

namespace UoM.Models
{
    public abstract class Length : IComparable
    {
        public string UnitName { get; }
        public string UnitsName { get; }
        public double Amount { get; private set; }
        
        /// <summary>
        /// What number, when multiplied by the amount, gives me the length in centimeters?
        /// </summary>
        abstract public double ConversionFactor { get; }

        protected double AmountInCm
        {
            get
            {
                return Amount * ConversionFactor;
            }
        }

        public Length(string unitName, string unitsName, double amount)
        {
            this.UnitName = unitName;
            this.UnitsName = unitsName;
            this.Amount = amount;
        }


        public override string ToString()
        {
            return $"{Amount} {(Amount == 1.0 ? UnitName : UnitsName)}";
        }

        public int CompareTo(object obj)
        {
            Length otherObj = (Length)obj;
            return this.AmountInCm.CompareTo(otherObj.AmountInCm);
        }

    }
}
