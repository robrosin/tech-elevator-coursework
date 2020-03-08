using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Post.Web.DAL;
using Post.Web.Models;

namespace Post.Web.Controllers
{
    public class HomeController : Controller
    {
        private IReviewDAO reviewDAO;

        public HomeController(IReviewDAO reviewDAO)
        {
            this.reviewDAO = reviewDAO;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IList<ReviewModel> review = reviewDAO.GetAllReviews();
            return View(review);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new ReviewModel());
        }

        //[HttpPost]
        //public IActionResult SaveReview(ReviewModel post)
        //{
        //    int newReviewId = reviewDAO.SaveReview(post);

        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public IActionResult Add(ReviewModel review)
        {
            int newReviewId = reviewDAO.SaveReview(review);

            //return Redirect($"/city/ConfirmAdd/{newCityId}");
            return RedirectToAction("Index");

        }


        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
