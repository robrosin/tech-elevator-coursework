using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Validation.Web.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Please give a valid first name")]
        [StringLength(20)]
        public string FirstName { get; set; } // Max length 20 / REQ

        [Required(ErrorMessage = "Please give a valid last name")]
        [StringLength(20)]
        public string LastName { get; set; } // Max length 20 / REQ

        [Required(ErrorMessage = "Please enter a valid email address")]
        [EmailAddress]
        public string Email { get; set; } // Must be valid email address / REQ

        [Required(ErrorMessage = "Please confirm email")]
        [EmailAddress]
        public string ConfirmEmail { get; set; } // Must match Email

        [Required(ErrorMessage = "The password must be at least 8 characters long")]
        [StringLength(20, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; } // Must be more than 8 characters / REQ

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } // Must match Password

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; } // Must be valid date / REQ

        [Required]
        [Range(1, 10)]
        public int NumberOfTickets { get; set; } // Range 1-10 / REQ       

        public RegistrationViewModel(string firstName, string lastName, string email, string confirmEmail, string password, string confirmPassword, DateTime birthDate, int numberOfTickets)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ConfirmEmail = confirmEmail;
            Password = password;
            ConfirmPassword = confirmPassword;
            BirthDate = birthDate;
            NumberOfTickets = numberOfTickets;
        }
        public RegistrationViewModel()
        {
        }
    }
}