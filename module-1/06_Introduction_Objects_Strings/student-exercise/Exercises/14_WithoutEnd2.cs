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
         Given a string, return a version without both the first and last char of the string. The string
         may be any length, including 0.
         WithoutEnd2("Hello") → "ell"
         WithoutEnd2("abc") → "b"
         WithoutEnd2("ab") → ""
         */
        public string WithoutEnd2(string str)
        {
            // return str.Substring(1, (str.Length));


            int firstLast = str.Length;

            if (firstLast >= 3)
            {
                return str.Substring(1, firstLast - 2);
            }
            else
            {
                return "";
            }

        }
    }
}


