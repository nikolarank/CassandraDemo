using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlanArtMVC.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public string status { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        public string confirmPassword { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string city { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string firstname { get; set; }

        public string lastname { get; set; }

        public string nickname { get; set; }
    }
}