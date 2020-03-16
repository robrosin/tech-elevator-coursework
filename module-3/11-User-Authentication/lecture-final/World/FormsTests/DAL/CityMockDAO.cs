using Forms.Web.DAL;
using Forms.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormsTests.DAL
{
    class CityMockDAO : ICityDAO
    {
        private List<City> cities = new List<City>()
        {
            new City(1, "City1", "CC1", "Country1", "D1", 100000),
            new City(2, "City2", "CC1", "Country1", "D2", 200000),
            new City(3, "City3", "CC2", "Country2", "D3", 300000),
            new City(4, "City4", "CC2", "Country2", "D4", 400000),
        };

        public int MaxId {
            get
            {
                return cities.Max(c => c.CityId);
            }
        }

        public int AddCity(City city)
        {
            city.CityId = MaxId + 1;
            cities.Add(city);
            return city.CityId;
        }

        public void DeleteCity(int cityId)
        {
            cities.RemoveAll(c => c.CityId == cityId);
        }

        public IList<City> GetCities()
        {
            return new List<City>(cities);
        }

        public IList<City> GetCities(string countryCode, string district)
        {
            countryCode = countryCode.Trim().ToLower();
            district = district.Trim().ToLower();
            return cities.Where(c => c.CountryCode.ToLower() == countryCode && (district.Length == 0 || c.District.Contains(district))).ToList();
        }

        public City GetCityById(int id)
        {
            return cities.Where(c => c.CityId == id).FirstOrDefault();
        }

        public void UpdateCity(City city)
        {
            // Find the city with the id
            City oldCity = GetCityById(city.CityId);

            if (oldCity == null)
            {
                throw new ArgumentException($"UpdateCity: Could not find a city with id = {city.CityId}.");
            }

            oldCity.CountryCode = city.CountryCode;
            oldCity.District = city.District;
            oldCity.Name = city.Name;
            oldCity.Population = city.Population;
        }
    }
}
