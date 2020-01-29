using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Classes
{
    public class Person : IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int HeightInches { get; set; }

        public Person(string first, string last, int age, int height)
        {
            FirstName = first;
            LastName = last;
            Age = age;
            HeightInches = height;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: Age {Age}, Height {HeightInches} inches.";
        }


        public int CompareTo(object obj)
        {
            if (obj is Person)
            {
                Person thePersonToCompareTo = (Person)obj;

                // Sort by Last Name
                return this.LastName.CompareTo(thePersonToCompareTo.LastName);

                //    //// Sort by First Name
                //    //return this.FirstName.CompareTo(other.FirstName);

                // Sort by Age
                //return this.Age - other.Age;

                //    ////Sort by Height
                //    //return this.HeightInches - other.HeightInches;
            }
            else
            {
                return 0;
            }
        }
    }
}
