using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class KataFizzBuzz
    {
        public string fizzBuzz(int num)
        {
            if (num < 1 || num > 100)
            {
                return "";
            }
            if ((num % 15 == 0) || (num.ToString().Contains("3") && num.ToString().Contains("5")))
            {
                return "FizzBuzz";
            }
            if ((num % 5 == 0) || (num.ToString().Contains("5")))
            {
                return "Buzz";
            }
            if ((num % 3 == 0) || (num.ToString().Contains("3")))
            {
                return "Fizz";
            }
            return num.ToString();
        }
    }
}