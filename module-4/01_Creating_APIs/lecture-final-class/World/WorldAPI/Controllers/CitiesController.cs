using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldLib.DAL;
using WorldLib.Models;

namespace WorldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private ICityDAO cityDao;
        public CitiesController(ICityDAO cityDao)
        {
            this.cityDao = cityDao;
        }

        // /api/cities -- get all cities
        // /api/cities? countrycode=usa&district=ohio   -- get filtered cities

            /// <summary>
            /// 
            /// </summary>
            /// <param name="countrycode"></param>
            /// <param name="district"></param>
            /// <returns></returns>
        [HttpGet("")]
        public IActionResult GetCities(string countrycode, string district)
        {
            if (countrycode == null && district == null)
            {
                return new JsonResult(cityDao.GetCities());
            }
            else
            {
                return new JsonResult( cityDao.GetCities(countrycode, district ));
            }
        }


        // /api/cities/{id} -- get a city by its id
        [HttpGet("{id}", Name ="GetTheCity")]   // responds to "api/[controller]/{id}"
        public IActionResult GetCityById(int id)
        {
            City city = cityDao.GetCityById(id);

            if (city == null)
            {
                return NotFound();
            }
            else
            {
                return new JsonResult(city);
            }
        }

        // POST /api/cities
        [HttpPost()]
        public IActionResult AddCity(City city)
        {
            if (ModelState.IsValid)
            {
                int newId = cityDao.AddCity(city);

                // Read the city back to return it.
                city = cityDao.GetCityById(newId);

                // Return 201 Created, with a resource location pointing to our GetCity route
                return CreatedAtRoute("GetTheCity", new { id = newId }, city);
            }
            else
            {
                // Pass errors back to the client program
                return new BadRequestObjectResult(ModelState);
            }


        }

        // PUT /api/cities/101
        [HttpPut("{id}")]
        public IActionResult UpdateCity(City city)
        {
            if (ModelState.IsValid)
            {
                cityDao.UpdateCity(city);
                return Ok();
            }
            else
            {
                // Pass errors back to the client program
                return new BadRequestObjectResult(ModelState);
            }
        }

        // DELETE /api/cities/101
        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            cityDao.DeleteCity(id);
            return Ok();
        }
    }
}