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
        // TODO: Declare a private field to hold the Film DAO passed in during construction (Dependency Injection)
        public FilmsController()
        {
            // TODO: Add a IStarWarsDAO parameter to the constructor to be passed in using DI, and save it into the private field
        }
        public IActionResult Index()
        {
            // Get a list of all films
            IStarWarsDAO dao = new MockStarWarsDAO();

            // TODO: Change this DAO to a SQL DAO to get the "production" data

            IList<Film> films = dao.GetFilms();

            return View(films);
        }

        public IActionResult Detail(string id)
        {
            // Find the film with the given id and display it in the default view
            IStarWarsDAO dao = new MockStarWarsDAO();

            // TODO: Change this DAO to a SQL DAO to get the "production" data

            Film film = dao.GetFilm(id);

            return View(film);
        }

        public IActionResult Search(FilmSearch search)
        {
            // TODO: Show model binding into the FilmSearch object

            // If values were passed in, do a search. If not show the view with no model

            // TODO: Use ViewData to pass a "Message" into the view.  
            // TODO: Add code to _Layout to look for that message.
            if (search == null || (search.SearchFor == null && search.Series == null))
            {
                return View();
            }
            // Get List of films that match the search
            IStarWarsDAO dao = new MockStarWarsDAO();

            // TODO: Change this DAO to a SQL DAO to get the "production" data

            IList<Film> films = dao.GetFilms(search.SearchFor, search.Series);

            // TODO: If no films were returned, show a "Message" to the use that there were no search results.

            return View(films);
        }
    }
}