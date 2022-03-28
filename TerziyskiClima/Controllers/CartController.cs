using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerziyskiClima.Data.Models;
using TerziyskiClima.Models;
using TerziyskiClima.Services;
using TerziyskiClima.Services.Extensions;

namespace TerziyskiClima.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductService productService;
        private readonly CartService cartService;

        public CartController(ProductService _productService, CartService _cartService)
        {
            productService = _productService;
            cartService = _cartService;
        }

        public IActionResult Index()
        {
            ViewBag.Items = new List<CartItem>();
            string cartContentString = HttpContext.Session.GetString(Global.CartSessionKey);

            if (!string.IsNullOrEmpty(cartContentString))
            {
                Cart cartContent = cartContentString.ToCart();
                ViewBag.Items = cartContent.Items;
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            string cartContentString = HttpContext.Session.GetString(Global.CartSessionKey);
            if (string.IsNullOrEmpty(cartContentString))
            {
                cartContentString = JsonConvert.SerializeObject(new Cart());
                HttpContext.Session.SetString(Global.CartSessionKey, cartContentString);
            }
            Product productToAdd = productService.GetProductById(productId);
            string newCartContentString = cartService.AddToCart(productToAdd, cartContentString);

            HttpContext.Session.SetString(Global.CartSessionKey, newCartContentString);

            return RedirectToAction("Index", "Product");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            string cartContentString = HttpContext.Session.GetString(Global.CartSessionKey);
            if (string.IsNullOrEmpty(cartContentString)) return RedirectToAction("Index");

            string newCartContentString = cartService.RemoveFromCart(productId, cartContentString);

            HttpContext.Session.SetString(Global.CartSessionKey, newCartContentString);

            return RedirectToAction("Index");
        }
    }
}