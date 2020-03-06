using Forms.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.DAL
{
    public interface ICityDAO
    {
        City GetCityById(int id);
        IList<City> GetCities();
        IList<City> GetCities(string countryCode, string district);
        int AddCity(City city);
        void UpdateCity(City city);
        void DeleteCity(int cityId);
    }
}
