﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TE.AuthLib;

namespace Recipes.Controllers
{
    /// <summary>
    /// RecipesBaseController is a base class for all our application's controller, and
    /// therefore makes a convenient place to put useful methods all controllers might use.  
    /// For example, the Home and Recipe controllers both need to get and store preference information
    /// in Session, so those methods are defined here. Displaying a message to the user is also
    /// conveniently defined here.
    /// </summary>
    public abstract class RecipesBaseController : Controller
    {
        // TODO 02 (Controller): in our base-class controller, get access to the authProvider if needed. Use DI in the constructor.
        protected IAuthProvider authProvider;

        public RecipesBaseController(IAuthProvider authProvider)
        {
            this.authProvider = authProvider;
        }

        // TODO 02 (Controller): Add methods so any controller can see if there is a user logged in and 
        // get the current user.
        protected bool LoggedIn
        {
            get
            {
                return authProvider.IsLoggedIn;
            }
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (LoggedIn)
            {
                ViewData["CurrentUser"] = authProvider.GetCurrentUser();
            }
        }

        // The session key used for Cuisine
        private const string cuisineSessionKey = "PreferredCuisine";

        protected string GetPreferredCuisine()
        {
            return HttpContext.Session.GetString(cuisineSessionKey) ?? "";
        }

        protected void SetPreferredCuisine(string cuisine)
        {
            if (cuisine == null || cuisine.Trim().Length == 0)
            {
                ClearPreferredCuisine();
            }
            else
            {
                HttpContext.Session.SetString(cuisineSessionKey, cuisine);
            }
        }

        protected void ClearPreferredCuisine()
        {
            HttpContext.Session.Remove(cuisineSessionKey);
        }

        /// <summary>
        /// Sets a message into TempData.  Our _Layout view looks for this message
        /// and displays it if present.
        /// </summary>
        /// <param name="message">Message to display</param>
        protected void SetMessage(string message)
        {
            TempData["message"] = message;
        }
    }
}