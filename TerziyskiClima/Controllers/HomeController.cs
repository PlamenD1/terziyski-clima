using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TerziyskiClima.Data.Models;
using TerziyskiClima.Models;
using TerziyskiClima.Services;

namespace TerziyskiClima.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService productService;


        public HomeController(ILogger<HomeController> logger, ProductService _productService)
        {
            _logger = logger;
            productService = _productService;
        }

        public IActionResult Index()
        {
            List<Product> featuredProducts = productService.GetProducts();
            ViewBag.FeaturedProducts = featuredProducts;
            ViewBag.LoggedIn = HttpContext.User.Claims.Count()>0;
            if(ViewBag.LoggedIn)
               ViewBag.Email = HttpContext.User.Claims.ToList()[1].Value;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
