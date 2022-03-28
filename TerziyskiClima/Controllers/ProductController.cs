using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TerziyskiClima.Data.Models;
using TerziyskiClima.Services;

namespace TerziyskiClima.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService productService;
        private readonly AuthenticationService authenticationService;

        public ProductController(ProductService _productService, AuthenticationService _authenticationService)
        {
            productService = _productService;
            authenticationService = _authenticationService;
        }


        public IActionResult Index()
        {
            ViewBag.Role = authenticationService.GetRole(HttpContext.User);
            List<Product> products = productService.GetProducts();
            ViewBag.Products = productService.GetProducts() == null ? new List<Product>() : products;
            return View();
        }

        [Authorize(Policy = "AdminOnly")]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Add(string txtName, decimal txtPrice, string txtDescription)
        {
            productService.Add(txtName, txtPrice, txtDescription);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int txtId)
        {
            Product productToEdit = productService.GetProductById(txtId);
            ViewBag.Product = productToEdit;
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Edit(int txtId, string txtName, decimal txtPrice, string txtDescription)
        {
            productService.Edit(txtId, txtName, txtPrice, txtDescription);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Delete(int id)
        {
            productService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}