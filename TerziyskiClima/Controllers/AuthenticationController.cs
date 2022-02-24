using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerziyskiClima.Data.Models;
using TerziyskiClima.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace TerziyskiClima.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserService userService;
        public AuthenticationController(UserService _userService)
        {
            userService = _userService;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string txtFirstName, string txtLastName, string txtEmail, string txtAddress, string txtPhone, string txtPassword, string txtConfirmPassword, string txtRole)
        {
            User user = userService.Register(txtFirstName, txtLastName, txtAddress, txtPhone, txtEmail, txtPassword, txtConfirmPassword, txtRole);
            if(user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Email", user.Email),
                    new Claim("Role", user.Role)
                };
                var ClaimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var Principal = new ClaimsPrincipal(ClaimIdentity);
                var Props = new AuthenticationProperties();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, Principal, Props).Wait();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string txtEmail, string txtPassword)
        {
            User user = userService.Login(txtEmail, txtPassword);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Email", user.Email),
                    new Claim("Role", user.Role)
                };
                var ClaimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var Principal = new ClaimsPrincipal(ClaimIdentity);
                var Props = new AuthenticationProperties();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, Principal, Props).Wait();
                return RedirectToAction("Index", "Home");
            }
                
            else
            {
                ViewBag.Error = "Invalid Password or Email";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
