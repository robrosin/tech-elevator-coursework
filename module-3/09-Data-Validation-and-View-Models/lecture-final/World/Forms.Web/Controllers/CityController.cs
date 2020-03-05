using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forms.Web.DAL;
using Forms.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Forms.Web.Controllers
{
    public class CityController : Controller
    {

        /**** DEPENDENCY INJECTION *****/
        private ICityDAO cityDAO;
        private ICountryDAO countryDAO;
        public CityController(ICityDAO cityDAO, ICountryDAO countryDAO)
        {
            this.cityDAO = cityDAO;
            this.countryDAO = countryDAO;
        }

        public IActionResult Index()
        {
            IList<City> cities = cityDAO.GetCities();
            return View(cities);
        }

        public IActionResult Search(CitySearchVM vm)
        {
            // TODO 01: NOTE we are setting a Message if there is no search criteria
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
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // Create an Add (POST) method to get the form data and call the dao to add a city
        [HttpPost]
        public IActionResult Add(City city)
        {
            // TODO 07: Check model state before updating. If there are errors, return the form to the user.
            if (!ModelState.IsValid)
            {
                return View(city);
            }

            int newCityId = cityDAO.AddCity(city);

            // TODO 02a: Add a confirmation message to the user and then re-direct to the search page
            // TODO 03: Change from ViewData to TempData (here and in Layout, and above).
            ViewData["Message"] = $"City '{city.Name}' was added with id {newCityId}";

            // TODO 02b: Redirect to the search page so the user can see the added city, instead of to the 
            // Confirm page
            return RedirectToAction("ConfirmAdd", new { id = newCityId });
        }
        // ConfirmAdd (GET) method to read the added city and call the view
        [HttpGet]
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
        public IActionResult Delete(City city)
        {
            cityDAO.DeleteCity(city.CityId);
            return RedirectToAction("ConfirmDelete");
        }

        // ConfirmDelete (GET) method call the view to confirm
        [HttpGet]
        public IActionResult ConfirmDelete()
        {
            return View();
        }


        // TODO 08:  Implement flow to UPDATE a city
        // TODO 08a: Create an Update (GET) method to handle the request and show the form
        // TODO 08b: Create the Update City form to show / get information to the user
        // TODO 08c: Create an Update (POST) method to call the dao to update a city
        // TODO 08d: Redirect to the Update (GET) page

    }
}