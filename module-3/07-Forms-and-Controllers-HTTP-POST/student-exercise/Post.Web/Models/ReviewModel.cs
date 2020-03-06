using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Post.Web.Models
{
    public class ReviewModel
    {
        public string UserName { get; set; }
        public int Rating { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }

        public ReviewModel() { }

        public ReviewModel(string username, int rating, string reviewTitle, string reviewText, DateTime reviewDate)
        {
            UserName = username;
            Rating = rating;
            ReviewTitle = reviewTitle;
            ReviewText = reviewText;
            ReviewDate = reviewDate;
        }
    }
}
