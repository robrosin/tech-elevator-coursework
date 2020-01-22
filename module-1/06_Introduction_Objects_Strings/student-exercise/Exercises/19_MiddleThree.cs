using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class StringExercises
    {
        /*
         Given a string of odd length, return the string length 3 from its middle, so "Candy" yields "and".
         The string length will be at least 3.
         MiddleThree("Candy") → "and"
         MiddleThree("and") → "and"
         MiddleThree("solving") → "lvi"
         */
        public string MiddleThree(string str)
        {
            int mid3 = (str.Length);

            if (mid3 > 3)
            {
                int mid4 = (mid3 / 2);
                return str.Substring(mid4 - 1, 3);
            }
            else
            {
                return str;
            }
        }
    }

}