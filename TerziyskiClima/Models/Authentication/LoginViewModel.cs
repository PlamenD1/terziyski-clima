using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TerziyskiClima.Models.Authentication
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email е задължителен")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Паролата е задължителна")]
        public string Password { get; set; }

        public bool ShowError { get; set; } = false;
        public string Error { get; set; }
    }
}