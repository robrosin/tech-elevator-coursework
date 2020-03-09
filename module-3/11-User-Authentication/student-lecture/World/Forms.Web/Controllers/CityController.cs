using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forms.Web.DAL;
using Forms.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TE.AuthLib;

namespace Forms.Web.Controllers
{
    public class CityController : AppController
    {

        /**** DEPENDENCY INJECTION *****/
        private ICityDAO cityDAO;
        private ICountryDAO countryDAO;

        // TODO 02 (Controller): Derive the city controller from AppController so we have access to authProvider
        // Note that we have to inject an IAuthProvider and pass it to the base contructor
        public CityController(ICityDAO cityDAO, ICountryDAO countryDAO, IAuthProvider authProvider) : base(authProvider)
        {
            this.cityDAO = cityDAO;
            this.countryDAO = countryDAO;
        }

        // TODO 06 (Controller): Authorize...ANY user can get a data dump
        public IActionResult Index()
        {
            IList<City> cities = cityDAO.GetCities();
            return View(cities);
        }

        // TODO 06 (Controller): Authorize...You must be logged in to use our sophisticated data tools
        public IActionResult Search(CitySearchVM vm)
        {
            // NOTE we are setting a Message if there is no search criteria
            if (vm.CountryCode == null && vm.District == null)
            {
                ViewData["Message"] = "Enter search criteria";
                vm.Cities = new List<City>();
            }
            else
            {
                vm.Cities = cityDAO.GetCities(vm.CountryCode, vm.District);
            }

            // Populate the country list on the view model
            // Call GetCountries() on the countryDAO.
            IList<Country> countries = countryDAO.GetCountries();
            vm.CountryList = new SelectList(countries, "Code", "Name");

            return View(vm);
        }

        // Implement the PRG pattern to ADD a city
        // Add (GET) action to show the form
        // TODO 06 (Controller): Authorize...You must be an ADMIN to update the database
        [HttpGet]
        public IActionResult Add()
        {
            City city = new City();
            return View(city);
        }

        // Create an Add (POST) method to get the form data and call the dao to add a city
        [HttpPost]
        // Add (GET) action to show the form
        // TODO 06 (Controller): Authorize...You must be an ADMIN to update the database
        public IActionResult Add(City city)
        {
            // Check model state before updating. If there are errors, return the form to the user.
            if (!ModelState.IsValid)
            {
                return View(city);
            }

            int newCityId = cityDAO.AddCity(city);

            // Add a confirmation message to the user and then re-direct to the search page
            TempData["Message"] = $"City '{city.Name}' was added with id {newCityId}";

            // Redirect to the search page
            CitySearchVM vm = new CitySearchVM()
            {
                CountryCode = city.CountryCode,
                District = city.District
            };
            return RedirectToAction("Search", vm);
        }

        // ConfirmAdd (GET) method to read the added city and call the view
        [HttpGet]
        // TODO 06 (Controller): Authorize...You must be an ADMIN to update the database
        public IActionResult ConfirmAdd(int id)
        {
            City city = cityDAO.GetCityById(id);
            return View(city);
        }

        // Detail (GET) method to handle the request and show the form
        [HttpGet]
        public IActionResult Detail(int id)
        {
            City city = cityDAO.GetCityById(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }


        // Implement the PRG pattern to DELETE a city
        // Delete (GET) method to handle the request and show the form and ask the user to confirm
        [HttpGet]
        // TODO 06 (Controller): Authorize...You must be an ADMIN to update the database
        public IActionResult Delete(int id)
        {
            City city = cityDAO.GetCityById(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // Delete (POST) method to call the dao to delete a city
        [HttpPost]
        // TODO 06 (Controller): Authorize...You must be an ADMIN to update the database
        public IActionResult Delete(City city)
        {
            cityDAO.DeleteCity(city.CityId);
            return RedirectToAction("ConfirmDelete");
        }

        // ConfirmDelete (GET) method call the view to confirm
        [HttpGet]
        // TODO 06 (Controller): Authorize...You must be an ADMIN to update the database
        public IActionResult ConfirmDelete()
        {
            return View();
        }

        // TODO 00:  Implement flow to UPDATE a city
        // TODO 00 (Controller): Create an Update (GET) method to handle the request and show the form
        [HttpGet]
        // TODO 06 (Controller): Authorize...You must be an ADMIN to update the database
        public IActionResult Update(int id)
        {
            // Find the city to update
            City city = cityDAO.GetCityById(id);
            if (city == null)
            {
                return NotFound();
            }

            // Show the form
            return View(city);
        }

        // TODO 00 (Controller): Create an Update (POST) method to call the dao to update a city
        // TODO 06 (Controller): Authorize...You must be an ADMIN to update the database
        public IActionResult Update(City city)
        {
            // Check model state before updating. If there are errors, return the form to the user.
            if (!ModelState.IsValid)
            {
                return View(city);
            }

            cityDAO.UpdateCity(city);

            // Add a confirmation message to the user and then re-direct to the search page
            TempData["Message"] = $"City '{city.Name}' was updated";

            // TODO 00 (Controller): Redirect to the Update (GET) page, to re-display the city
            return RedirectToAction("Update", new { id = city.CityId });
        }
    }
}