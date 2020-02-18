using System;
using System.Collections.Generic;
using System.Text;
using WorldDB.Models;

namespace WorldDB.DAL
{
    public interface ICityDAO
    {
        /// <summary>
        /// Gets all cities provided a country code.
        /// </summary>
        /// <param name="countryCode">The country code to search for.</param>
        /// <returns></returns>
        IList<City> GetCitiesByCountryCode(string countryCode);

        /// <summary>
        /// Adds a new city.
        /// </summary>
        /// <param name="city">The city to add.</param>
        bool AddCity(City city);

        /// <summary>
        /// Given an id, get the city identified by that id.
        /// </summary>
        /// <param name="id">Id of a city</param>
        /// <returns>City object for the id, NULL if the id does not exist</returns>
        City GetCityById(int id);

    }
}
