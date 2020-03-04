using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SessionExercise.Web.Extensions;

namespace SessionExercise.Web.Controllers
{
    public class FavoriteThingsController : Controller
    {
        [HttpGet]
        public IActionResult Page1()
        {
            return View(nameof(Page1));
        }
    }
}
