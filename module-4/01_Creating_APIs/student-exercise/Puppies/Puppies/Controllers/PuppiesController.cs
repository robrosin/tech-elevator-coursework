using Microsoft.AspNetCore.Mvc;
using Puppies.DAL;
using Puppies.Models;
using System.Collections.Generic;

namespace Puppies.Web.Controllers
{
    public class PuppiesController : Controller
    {
        private IPuppyDao puppyDao;

        public PuppiesController(IPuppyDao puppyDao)
        {
            this.puppyDao = puppyDao;
        }

        [HttpGet]
        public IActionResult Index()
        {
            PuppyViewModel vm = new PuppyViewModel();
            vm.Puppies = puppyDao.GetPuppies();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(PuppyViewModel vm)
        {
            if (ModelState.IsValid)
            {
                puppyDao.AddPuppy(vm.NewPuppy);
                return RedirectToAction("Index");
            }
            vm.Puppies = puppyDao.GetPuppies();
            return View(vm);
        }

        public IActionResult Detail(int id)
        {
            Puppy puppy = puppyDao.GetPuppy(id);
            return View(puppy);
        }
    }
}
