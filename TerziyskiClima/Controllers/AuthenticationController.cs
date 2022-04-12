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
using TerziyskiClima.Models.Authentication;

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
            RegisterViewModel viewModel = new RegisterViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                User user = userService.Register(
                    viewModel.Name,
                    viewModel.Surname,
                    viewModel.Address,
                    viewModel.Phone,
                    viewModel.Email,
                    viewModel.Password
                    );
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim("Id", user.Id.ToString()),
                        new Claim("Email", user.Email),
                        new Claim(ClaimTypes.Role, user.Role)
                    };
                    var ClaimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var Principal = new ClaimsPrincipal(ClaimIdentity);
                    var Props = new AuthenticationProperties();
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, Principal, Props).Wait();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(viewModel);
                }
            }
            else return View(viewModel);
        }

        public IActionResult Login()
        {
            LoginViewModel viewModel = new LoginViewModel();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                User user = userService.Login(viewModel.Email, viewModel.Password);
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim("Id", user.Id.ToString()),
                        new Claim("Email", user.Email),
                        new Claim(ClaimTypes.Role, user.Role)
                    };
                    var ClaimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var Principal = new ClaimsPrincipal(ClaimIdentity);
                    var Props = new AuthenticationProperties();
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, Principal, Props).Wait();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    viewModel.Error = "Неправилна парола или email";
                    viewModel.ShowError = true;
                    return View(viewModel);
                }
            }
            else
            {
                return View(viewModel);
            }
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult VerifyEmail(string email)
        {
            if (userService.EmailIsUsed(email))
            {
                return Json($"E-mail {email} вече се използва");
            }

            return Json(true);
        }

        public IActionResult VerifyPhone(string phone)
        {
            if (userService.PhoneIsUsed(phone))
            {
                return Json($"Телефонът {phone} вече се използва");
            }

            return Json(true);
        }
    }
}
