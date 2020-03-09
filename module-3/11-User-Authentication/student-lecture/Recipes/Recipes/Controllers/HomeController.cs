using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Recipes.DAL;
using Recipes.Models;
using TE.AuthLib;

namespace Recipes.Controllers
{
    /**********************
     * 
     * TASK LIST:
     * 
     * 
     *********************/
    public class HomeController : RecipesBaseController
    {
        private IRecipeDAO recipeDAO = null;
        public HomeController(IRecipeDAO recipeDAO, IAuthProvider authProvider) : base(authProvider)
        {
            this.recipeDAO = recipeDAO;
        }

        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public IActionResult Index()
        {
            Preferences pref = new Preferences()
            {
                Cuisine = GetPreferredCuisine(),

            };
            pref.Cuisines = new SelectList(recipeDAO.GetCuisines());
            return View(pref);
        }

        [HttpGet]
        public IActionResult Preferences()
        {
            Preferences pref = new Preferences()
            {
                Cuisine = GetPreferredCuisine(),
                
            };
            pref.Cuisines = new SelectList(recipeDAO.GetCuisines());
            return View(pref);
        }

        [HttpPost]
        public IActionResult Preferences(Preferences pref)
        {
            if (pref.Cuisine == null || pref.Cuisine.Length == 0)
            {
                ClearPreferredCuisine();
            }
            SetPreferredCuisine(pref.Cuisine);
            SetMessage($"Your preferred cuisine is now {(pref.Cuisine == null || pref.Cuisine == "" ? "Anything" : pref.Cuisine)}. Visit the Preferences page to change it.");
            return RedirectToAction("Index", "Recipe");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
