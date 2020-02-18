using System;
using System.Collections.Generic;
using System.Text;
using WorldDB.Models;

namespace WorldDB.DAL
{
    public interface ICountryDAO
    {

        /// <summary>
        /// Get the country identified by the given country code.
        /// </summary>
        /// <param name="countryCode">Code (identifier) of the country to lookup</param>
        /// <returns>A country object, or NULL if the code is invalid</returns>
        Country GetCountryByCode(string countryCode);

        /// <summary>
        /// Gets all countries.
        /// </summary>
        /// <returns></returns>
        IList<Country> GetCountries();

        /// <summary>
        /// Gets all countries for a continent.
        /// </summary>
        /// <param name="continent">The continent to filter by.</param>
        /// <returns></returns>
        IList<Country> GetCountries(string continent);

        /// <summary>
        /// Find a list of countries given a partial name and/or a partial continent name
        /// </summary>
        /// <param name="nameLike">portion of a country name</param>
        /// <param name="continentLike">portion of a continent name</param>
        /// <returns>A <list type="of Country objects that match the search.</returns>
        IList<Country> SearchCountriesByNameAndContinent(string nameLike, string continentLike);

    }
}
