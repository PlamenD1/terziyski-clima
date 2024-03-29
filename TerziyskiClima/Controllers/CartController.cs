﻿using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Policy = "NoAnonymous")]
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
            List<CartItem> items = new List<CartItem>();
            string cartContentString = HttpContext.Session.GetString(Global.CartSessionKey);

            if (!string.IsNullOrEmpty(cartContentString))
            {
                Cart cartContent = cartContentString.ToCart();
                items = cartContent.Items;
            }
            return View(items);
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
        public IActionResult ChangeQuantity(int productId, int quantity)
        {
            string cartContentString = HttpContext.Session.GetString(Global.CartSessionKey);
            if (string.IsNullOrEmpty(cartContentString)) return RedirectToAction("Index");
            string newCartContentString = cartService.ChangeQuantity(productId, quantity, cartContentString);

            HttpContext.Session.SetString(Global.CartSessionKey, newCartContentString);

            return RedirectToAction("Index");
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