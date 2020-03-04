namespace GETForms.Web.Controllers
{
    public class FilmSearch
    {
        public string Genre { get; set; }
        public int MinimumLength { get; set; }
        public int MaximumLength { get; set; }
    }
}

//        [Display(Name = "Enter a minimum length")]
//        public int MinimumLength { get; set; }

//        [Display(Name = "Enter a maximum length")]
//        public int MaximumLength { get; set; }

//        [Display(Name = "Enter a genre")]

//        public string Genre { get; set; }

//        public FilmSearch()
//        {
//            MinimumLength = 0;
//            MaximumLength = 1000;
//        }

//        public static List<SelectListItem> Genres = new List<SelectListItem>()
//        {
//            new SelectListItem() { Text = "Action" },
//            new SelectListItem() { Text = "Animation" },
//            new SelectListItem() { Text = "Children" },
//            new SelectListItem() { Text = "Classics" },
//            new SelectListItem() { Text = "Comedy" },
//            new SelectListItem() { Text = "Documentary" },
//            new SelectListItem() { Text = "Drama" },
//            new SelectListItem() { Text = "Family" },
//            new SelectListItem() { Text = "Foreign" },
//            new SelectListItem() { Text = "Games" },
//            new SelectListItem() { Text = "Horror" },
//            new SelectListItem() {Text = "Music" },
//            new SelectListItem() { Text = "New" },
//            new SelectListItem() { Text = "Sci-Fi" },
//            new SelectListItem() { Text = "Sports" },
//            new SelectListItem() { Text = "Travel" }
//        };
//    }
//}