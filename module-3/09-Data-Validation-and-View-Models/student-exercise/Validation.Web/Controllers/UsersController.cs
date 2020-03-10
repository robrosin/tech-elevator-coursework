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
        [HttpGet]
        public IActionResult Registration()
        {
            return View("Registration");
        }

        // POST: User/Register
        // Validate the model and redirect to confirmation (if successful) or return the
        // registration view (if validation fails)

        [HttpPost]
        public IActionResult Registration(RegistrationViewModel registration)
        {
            if (!ModelState.IsValid)
            {
                return View(registration);
            }
            return RedirectToAction("RegConfirmation");
        }


        // GET: User/Login
        // Return the empty login view
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        // POST: User/login
        // Validate the model and redirect to a confirmation page if validation is
        // successful. Return the login view (if validation fails).
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            return RedirectToAction("Confirmation");
        }


        // GET: User/Confirmation
        // Return the confirmation view
        [HttpGet]
        public IActionResult Confirmation()
        {
            return View("Confirmation");
        }

        [HttpGet]
        public IActionResult RegConfirmation()
        {
            return View("RegConfirmation");
        }
    }
}