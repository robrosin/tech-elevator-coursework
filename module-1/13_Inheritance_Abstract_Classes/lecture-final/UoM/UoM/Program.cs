using System;
using System.Collections.Generic;
using UoM.Models;

namespace UoM
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Create a few classes derived from Length. (inches, centimeter, meter, foot, yard)
            Inch i3 = new Inch(3);
            Length len = new Foot(1);
            List<Length> lengths = new List<Length>()
            {
                new Inch(6),
                new Foot(.4),
                new Centimeter(10),
                new Centimeter(8),
                i3,
                new Inch(5),
                len
            };

            lengths.Sort();

            foreach (Length l in lengths)
            {
                Console.WriteLine(l);
            }

            List<Person> people = new List<Person>()
            {
                new Person(){FirstName = "Mike", LastName = "Morel" },
                new Person(){FirstName = "Chelsea" }
            };

            Person p = new Person()
            {
                FirstName = "Mike",
                LastName = "Morel",
                Age = 57,
                Height = 71
            };



            Console.ReadKey();
        }
    }
}
