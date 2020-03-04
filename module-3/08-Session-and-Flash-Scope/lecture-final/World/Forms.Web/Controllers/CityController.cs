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
            if (vm.CountryCode == null && vm.District == null)
            {
                ViewData["Message"] = "Enter search criteria";
                vm.Cities = new List<City>();
            }
            else
            {
                vm.Cities = cityDAO.GetCities(vm.CountryCode, vm.District);
            }

            // TODO 01c: Populate the country list on the view model by calling GetCountrySelectList

            // Call GetCountries() on the countryDAO

            // TODO 01: Add a SelectList to the view-model for country codes. 
            // TODO 01b: Add a method to Generate Select List from the Country DAO. (GetCountrySelectList)
            //          This will require us to ask for another "injected" DAO
            IList<Country> countries = countryDAO.GetCountries();
            vm.CountryList = new SelectList(countries, "Code", "Name");

            return View(vm);
        }



    

        // TODO 03: Implement the PRG pattern to add a new city
        // TODO 03a: Create an Add (GET) method to handle the request and show the form
        // TODO 03b: Create the Add City form to get information from the user
        // TODO 03c: Create an Add (POST) method to get the form data and call the dao to add a city
        // TODO 03d: Create the confirmation (Get) method to read the added city and call the view
        // TODO 03e: Create the Confirmation page to show the successful Add

        // Add (GET) action to swhow the form

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(City city)
        {
            int newCityId = cityDAO.AddCity(city);

            //return Redirect($"/city/ConfirmAdd/{newCityId}");
            return RedirectToAction("ConfirmAdd", new { id = newCityId});
        }

        [HttpGet]
        public IActionResult ConfirmAdd(int id)
        {
            City city = cityDAO.GetCityById(id);

            return View(city);
        }


        // TODO 05: Create a City Detail page
        // TODO 05a: Create a Detail (GET) method to handle the request and show the form
        // TODO 05b: Create the City Detail form to show information from the user. Include links to UPD and DEL.
        // TODO 05C: Update the city listing (partial) to include a link to the city detail
        public IActionResult Detail(int id)
        {
            City city = cityDAO.GetCityById(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }


        // TODO 06: Implement the PRG pattern to DELETE a city
        // TODO 06a: Create a Delete (GET) method to handle the request and show the form
        // TODO 06b: Create the Delete City form to show information to the user and confirm
        // TODO 06c: Create a Delete (POST) method to call the dao to delete a city
        // TODO 06d: Create the confirmation (Get) method call the view to confirm
        // TODO 06e: Create the Confirmation page to show the successful Delete
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

        [HttpPost]
        public IActionResult Delete(City city)
        {
            cityDAO.DeleteCity(city.CityId);
            return RedirectToAction("ConfirmDelete");
        }

        [HttpGet]
        public IActionResult ConfirmDelete()
        {
            return View();
        }


        // TODO 07: Implement flow to UPDATE a city
        // TODO 07a: Create an Update (GET) method to handle the request and show the form
        // TODO 07b: Create the Update City form to show / get information to the user
        // TODO 07c: Create an Update (POST) method to call the dao to update a city
        // TODO 07d: Redirect to the Update (GET) page

    }
}