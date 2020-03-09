using System.ComponentModel.DataAnnotations;

namespace Forms.Web.Models
{
    // TODO 04 (Model): Create the Login ViewModel for the form
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
