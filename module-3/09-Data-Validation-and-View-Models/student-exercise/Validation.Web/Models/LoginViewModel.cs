using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Validation.Web.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Please enter a valid email address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a valid password")]
        [StringLength(20, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public LoginViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public LoginViewModel()
        {
        }
    }
}