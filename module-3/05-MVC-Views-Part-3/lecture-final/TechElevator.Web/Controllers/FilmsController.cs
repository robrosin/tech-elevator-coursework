using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechElevator.Web.DAL;
using TechElevator.Web.Models;

namespace TechElevator.Web.Controllers
{
    public class FilmsController : Controller
    {
        //private const string connectionString = "Server=.\\SQLExpress;Database=SWDB; Trusted_Connection=True;";
        private IStarWarsDAO filmDAO;

        // TODO: Declare a private field to hold the Film DAO passed in during construction (Dependency Injection)
        public FilmsController(IStarWarsDAO filmDAO)
        {
            // TODO: Add a IStarWarsDAO parameter to the constructor to be passed in using DI, and save it into the private field
            this.filmDAO = filmDAO;
        }
        public IActionResult Index()
        {
            // Get a list of all films
            //            IStarWarsDAO dao = new MockStarWarsDAO();

            // Change this DAO to a SQL DAO to get the "production" data
            //IStarWarsDAO dao = new StarWarsSqlDAO(connectionString);

            IList<Film> films = filmDAO.GetFilms();

            return View(films);
        }

        public IActionResult Detail(string id)
        {
            // Find the film with the given id and display it in the default view
//            IStarWarsDAO dao = new MockStarWarsDAO();

            // TODO: Change this DAO to a SQL DAO to get the "production" data
            //IStarWarsDAO dao = new StarWarsSqlDAO(connectionString);

            Film film = filmDAO.GetFilm(id);

            return View(film);
        }

        public IActionResult Search(FilmSearch search)
        {

            // If values were passed in, do a search. If not show the view with no model

            // Use ViewData to pass a "Message" into the view.  
            // TODO: Add code to _Layout to look for that message.
            if (search == null || (search.SearchFor == null && search.Series == null))
            {
                ViewData["Message"] = "Please enter search critria and press Search";
                return View();
            }
            // Get List of films that match the search
//            IStarWarsDAO dao = new MockStarWarsDAO();

            // TODO: Change this DAO to a SQL DAO to get the "production" data
            //IStarWarsDAO dao = new StarWarsSqlDAO(connectionString);

            IList<Film> films = filmDAO.GetFilms(search.SearchFor, search.Series);

            // TODO: If no films were returned, show a "Message" to the use that there were no search results.
            if (films.Count == 0)
            {
                ViewData["Message"] = "Your search produced no results. Please try again.";
            }

            return View(films);
        }
    }
}