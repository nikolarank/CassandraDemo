using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlanArtMVC.Models
{
    public class RegistrationModel
    {
        //[Required(ErrorMessage = "Field can't be empty")]
        public string ImeRegistracija { get; set; }

        //[Required(ErrorMessage = "Field can't be empty")]
        public string PrezimeRegistracija { get; set; }

        //[Required(ErrorMessage = "Field can't be empty")]
        public string UsernameRegistracija { get; set; }

        //[Required(ErrorMessage = "Field can't be empty")]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string PasswordRegistracija { get; set; }

        //[Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.Password)]
        //[Compare("PasswordRegistracija", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPasswordRegistracija { get; set; }

        //[Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress)]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailRegistracija { get; set; }
    }
}