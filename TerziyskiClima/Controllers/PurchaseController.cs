using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerziyskiClima.Services;

namespace TerziyskiClima.Controllers
{
    [Authorize(Policy = "NoAnonymous")]
    public class PurchaseController : Controller
    {
        private readonly PurchaseService purchaseService;
        private readonly CartService cartService;

        public PurchaseController(PurchaseService _purchaseService, CartService _cartService)
        {
            purchaseService = _purchaseService;
            cartService = _cartService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PurchaseFromCart()
        {
            int userId = int.Parse(HttpContext.User.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value);
            string cartString = HttpContext.Session.GetString(Global.CartSessionKey);
            purchaseService.PurchaseFromCart(userId, cartString);
            string newCartString = cartService.ClearCart(cartString);
            HttpContext.Session.SetString(Global.CartSessionKey, newCartString);

            return RedirectToAction("Index");
        }
    }
}