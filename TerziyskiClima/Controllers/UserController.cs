using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerziyskiClima.Data.Models;
using TerziyskiClima.Services;

namespace TerziyskiClima.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService userService;
        public UserController(UserService _userService)
        {
            userService = _userService;
        }
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Index()
        {
            List<User> users = userService.GetUsers();
            return View(users);
        }

        [Authorize(Policy = "AdminOnly")]
        public IActionResult Review(int userId)
        {
            User user = userService.GetUserById(userId);
            return View(user);
        }
    }
}
