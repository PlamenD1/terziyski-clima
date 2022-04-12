using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TerziyskiClima.Data.Models;
using TerziyskiClima.Models.ProductViewModels;
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
            string role = authenticationService.GetRole(HttpContext.User);
            List<Product> products = productService.GetProducts();
            ProductIndexViewModel viewModel = new ProductIndexViewModel
            {
                Role = role,
                Products = products
            };
            return View(viewModel);
        }

        [Authorize(Policy = "AdminOnly")]
        public IActionResult Add()
        {
            ProductAddViewModel viewModel = new ProductAddViewModel();
            return View(viewModel);
        }


        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Add(ProductAddViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                productService.Add(viewModel.Name, viewModel.Price, viewModel.Description);
                return RedirectToAction("Index");
            }
            else return View(viewModel);
        }

        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Edit(int id)
        {
            Product productToEdit = productService.GetProductById(id);
            ProductEditViewModel viewModel = new ProductEditViewModel()
            {
                Id = productToEdit.Id,
                Name = productToEdit.Name,
                Price = Convert.ToDouble(productToEdit.Price),
                Description = productToEdit.Description,
            };
            
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Edit(ProductEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                productService.Edit(viewModel.Id, viewModel.Name, viewModel.Price, viewModel.Description);
                return RedirectToAction("Index");
            }
            else return View(viewModel);
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