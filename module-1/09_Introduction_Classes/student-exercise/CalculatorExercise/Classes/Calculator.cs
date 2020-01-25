using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{
    /// <summary>
    /// Represents a "simple" calculator
    /// </summary>
    public class Calculator
    {
        public int Result { get; private set; } = 0;

        public int Add(int addend)
        {
            return Result += addend;
        }
        public int Multiply(int multiplier)
        {
            return Result *= multiplier;
        }
        public int Subtract(int subtrahead)
        {
            return Result -= subtrahead;
        }
        public int Power(int exponent)
        {
            return Result = (int)Math.Abs(Math.Pow(Result, exponent));
        }
        public void Reset()
        {
            Result = 0;
        }
    }
}