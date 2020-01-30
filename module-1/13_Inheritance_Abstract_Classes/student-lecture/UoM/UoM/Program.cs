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
            List<Length> lengths = new List<Length>()
            {
                new Inch(6),
                new Foot(.4),
                new Centimeter(10),
                new Centimeter(8),
                new Inch(5),
            };

            lengths.Sort();
            foreach (Length l in lengths)
            {
                Console.WriteLine(l);
            }
            // TODO: Create a list of various lengths, and then sort the list.

            Console.ReadKey();
        }
    }
}