using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Assessment
{
    public class Movie_Rental
    {

        private Stream path;
        private string v;

        public Dictionary<string, Movie_Rental> MovieInfo { get; set; }
        public string Title { get; set; }
        public string Format { get; set; }
        public bool PremiumMovie { get; set; }
        public string RentalPrice { get; set; }

        public Movie_Rental(string title, string format, bool premiumMovie)
        {
            MovieInfo = new Dictionary<string, Movie_Rental>();
            using (System.IO.StreamReader rdr = new StreamReader(path))
            {
                string[] movieDetail;
                string line = "";
                while (!rdr.EndOfStream)
                {
                    line = rdr.ReadLine();
                    movieDetail = line.Split(",");
                    Movie_Rental movie = new Movie_Rental(movieDetail[0], movieDetail[1], bool.Parse(movieDetail[2]));
                    MovieInfo.Add(movie.Title, movie);
                }

            }
        }

        public Movie_Rental(string v)
        {
            this.v = v;
        }

    }
}

