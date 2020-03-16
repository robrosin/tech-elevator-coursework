using System;
using System.Collections.Generic;
using System.Linq;

namespace ParksAPI.DAL
{
    public interface IParkDAO
    {
        List<Park> GetAllParks();

        Park GetPark(string parkCode);

        //IList<WeatherModel> GetWeather(string parkCode, string tempUnit);
    }
}
