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
        private ICityDAO cityDAO;
        public CitiesController(ICityDAO cityDAO)
        {
            this.cityDAO = cityDAO;
        }
        // /api/cities -- get all cities
        // /api/cities?countrycode=usa&district=ohio -- get filtered cities

        [HttpGet]
        public IActionResult GetCities(string countrycode, string district)
        {
            if (countrycode == null && district == null)
            {
                return new JsonResult(cityDAO.GetCities());
            }
            else
            {
                return new JsonResult(cityDAO.GetCities(countrycode, district));
            }
        }

        // /api/cities/3 appends query string with id -- get a city by its id
        [HttpGet("{id}", Name = "GetCity")] // responds to "api/[controller]/id"
        public IActionResult GetCityById(int id)
        {
            City city = cityDAO.GetCityById(id);

            if (city == null)
            {
                return NotFound();
            }
            else
            {
                return new JsonResult(city);
            }

        }
        // POST /api/cities/
        [HttpPost()]
        public IActionResult AddCity(City city)
        {
            if (ModelState.IsValid)
            {
                int newId = cityDAO.AddCity(city);

                // Read the city back to return it

                city = cityDAO.GetCityById(newId);

                // Return 201 Created, with a resource location point to our GetCity route
                return CreatedAtRoute("GetCity", new { id = newId }, city);
            }
            else
            {
                // Pass errors back to the client program
                return new BadRequestObjectResult(ModelState);
            }
        }
        
        // PUT /api/cities/101
        [HttpPut("{id}")]
        public IActionResult UpdateCity (City city)
        {
            if (ModelState.IsValid)
            {
                cityDAO.UpdateCity(city);
                return Ok();
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }

        }

        // DELETE /api/cities/101
        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            cityDAO.DeleteCity(id);
            return Ok();
        }
    }
}
