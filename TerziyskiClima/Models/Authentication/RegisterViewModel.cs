using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TerziyskiClima.Models.Authentication
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Името е задължително")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Фамилията е задължителна")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "E-mail е задължителен")]
        [Remote(action: "VerifyEmail", controller: "Authentication")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Адресът е задължителен")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Телефонът е задължителен")]
        [RegularExpression(@"\d{10}", ErrorMessage = "Телефонът трябва да е точно 10 цифри")]
        [Remote(action: "VerifyPhone", controller: "Authentication")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Паролата е задължителна")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Потвърждаването на паролата е задължително")]
        [Compare("Password", ErrorMessage = "Паролите не съвпадат!")]
        public string ConfirmPassword { get; set; }
    }
}
