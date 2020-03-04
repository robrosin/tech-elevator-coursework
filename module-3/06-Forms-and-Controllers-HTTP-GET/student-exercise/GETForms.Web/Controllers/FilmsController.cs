using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GETForms.Web.DAL;
using GETForms.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GETForms.Web.Controllers
{
    public class FilmsController : Controller
    {

        private IFilmDAO filmDAO;

        public FilmsController(IFilmDAO filmDAO)
        {
            this.filmDAO = filmDAO;
        }

        /// <summary>
        /// The request to display an empty search page.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            FilmSearch filmSearch = new FilmSearch();
            return View(filmSearch);
        }

        /// <summary>
        /// Receives the search result request and goes to th database looking for the information.
        /// </summary>
        /// <param name="request">A request model that contains the search parameters.</param>
        /// <returns></returns>
        public ActionResult SearchResult(FilmSearch filmSearch)
        {
            /* Call the DAL and pass the values as a model back to the View */
            IList<Film> films = filmDAO.GetFilmsBetween(filmSearch.Genre, filmSearch.MinimumLength,
                filmSearch.MaximumLength);

            return View(films);
        }
    }
}