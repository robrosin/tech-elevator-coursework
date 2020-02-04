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
            if (num % 15 == 0)
            {
                return "FizzBuzz";
            }
            if (num == 3)
            {
                return "Fizz";
            }
            if (num == 5)
            {
                return "Buzz";
            }
            return num.ToString();
        }
    }
}