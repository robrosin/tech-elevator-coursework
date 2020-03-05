using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Validation.Web.Models;


namespace Validation.Web.Controllers
{
    public class UsersController : Controller
    {
        // GET: User
        public IActionResult Index()
        {
            return View("Index");
        }

        // GET: User/Register
        // Return the empty registration view

        // POST: User/Register
        // Validate the model and redirect to confirmation (if successful) or return the
        // registration view (if validation fails)

        // GET: User/Login
        // Return the empty login view

        // POST: User/login
	    // Validate the model and redirect to a confirmation page if validation is
	    // successful. Return the login view (if validation fails).

        // GET: User/Confirmation
        // Return the confirmation view

    }
}