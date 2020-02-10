using System;
using System.Collections.Generic;

namespace Assessment
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie_Rental mr = new Movie_Rental($"C:\\Users\\Student\\git\robrosin-c\\module-1\\Assessment\\student-assessment\\Assessment\\Data\\MovieInput.csv");

            foreach (KeyValuePair<string, Movie_Rental> field in mr.MovieInfo)
            {
                Console.WriteLine($"{field.Key} {field.Value.Title}, {field.Value.Format}, {field.Value.PremiumMovie}");
            }
        }
    }
}
