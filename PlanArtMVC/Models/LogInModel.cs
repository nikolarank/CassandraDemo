using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlanArtMVC.Models
{
    public class LogInModel
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public string UsernameLogIn { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.Password)]
        public string PasswordLogIn { get; set; }
    }
}