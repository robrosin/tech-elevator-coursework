using TechElevator.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechElevator.Web.DAL
{
    public class MockStarWarsDAO : IStarWarsDAO
    {
        // Mock Data used for the films data
        private List<Film> films = new List<Film>()
        {
            new Film() { Id = "solo", Name = "Solo: A Star Wars Story",
                Description="Board the Millennium Falcon and journey to a galaxy far, far away in Solo: A Star Wars Story, an all-new adventure with the most beloved scoundrel in the galaxy. Through a series of daring escapades deep within a dark and dangerous criminal underworld, Han Solo meets his mighty future copilot Chewbacca and encounters the notorious gambler Lando Calrissian, in a journey that will set the course of one of the Star Wars saga’s most unlikely heroes.",
                Series="Standalone",
                Length = 185, YearReleased = 2018, ImageUrl = "https://lumiere-a.akamaihd.net/v1/images/solo-theatrical-poster-1000_27861ab7.jpeg?region=0%2C279%2C1000%2C503&width=768"},
            new Film() { Id = "swviii", Name = "Star Wars Episode VIII: The Last Jedi", 
                Description="Rey has found the legendary Luke Skywalker, hoping to be trained in the ways of the Force. Meanwhile, the First Order seeks to destroy the remnants of the Resistance and rule the galaxy unopposed.",
                Series="Sequel",
                Length = 195, YearReleased = 2017, ImageUrl = "https://lumiere-a.akamaihd.net/v1/images/the-last-jedi-theatrical-poster-tall-a_6a776211.jpeg?region=0%2C53%2C1536%2C768&width=768"},
            new Film() { Id = "rogue-one", Name = "Rogue One: A Star Wars Story", 
                Description="From Lucasfilm comes the first of the Star Wars standalone films, 'Rogue One: A Star Wars Story,' an all-new epic adventure. In a time of conflict, a group of unlikely heroes band together on a mission to steal the plans to the Death Star, the Empire's ultimate weapon of destruction. This key event in the Star Wars timeline brings together ordinary people who choose to do extraordinary things, and in doing so, become part of something greater than themselves.",
                Series="Standalone",
                Length = 179, YearReleased = 2016, ImageUrl = "https://lumiere-a.akamaihd.net/v1/images/rogueone_onesheeta_8a255456.jpeg?region=0%2C77%2C1688%2C849&width=768"},
            new Film() { Id = "swix", Name = "Star Wars Episode IX",
                Description="A powerful enemy returns and Rey must face her destiny. The final chapter of the Skywalker saga comes home beginning March 17.",
                Series="Sequel",
                Length = 155, YearReleased = 2019, ImageUrl = "https://i0.wp.com/culturedvultures.com/wp-content/uploads/2019/04/Star-Wars-Episode-9.jpg" }
        };

        /// <summary>
        /// Returns all of the films.
        /// </summary>
        /// <returns></returns>
        public IList<Film> GetFilms()
        {
            return films;
        }

        /// <summary>
        /// Returns all of the films matching search criteria
        /// </summary>
        /// <returns></returns>
        public IList<Film> GetFilms(string searchFor, string series)
        {
            return films.Where(f => 
                (searchFor == null ||
                    f.Name.Contains(searchFor, StringComparison.InvariantCultureIgnoreCase) ||
                    f.Description.Contains(searchFor, StringComparison.InvariantCultureIgnoreCase))
                &&
                (series == null || f.Series == series)
            ).ToList();
        }

        /// <summary>
        /// Returns a single film
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Film GetFilm(string id)
        {
            return films.FirstOrDefault(film => film.Id.ToLower() == id.ToLower());
        }
    }
}
