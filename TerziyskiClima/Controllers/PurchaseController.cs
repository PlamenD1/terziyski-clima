using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerziyskiClima.Data.Models;
using TerziyskiClima.Services;

namespace TerziyskiClima.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly PurchaseService purchaseService;
        private readonly CartService cartService;

        public PurchaseController(PurchaseService _purchaseService, CartService _cartService)
        {
            purchaseService = _purchaseService;
            cartService = _cartService;
        }

        [Authorize(Policy = "NoAnonymous")]
        public IActionResult Index()
        {
            int userId = int.Parse(User.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value);
            List<Purchase> purchases = purchaseService.GetPurchasesByUserId(userId);
            return View(purchases);
        }

        [Authorize(Policy = "NoAnonymous")]
        public IActionResult PurchaseFromCart()
        {
            int userId = int.Parse(HttpContext.User.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value);
            string cartString = HttpContext.Session.GetString(Global.CartSessionKey);
            purchaseService.PurchaseFromCart(userId, cartString);
            string newCartString = cartService.ClearCart(cartString);
            HttpContext.Session.SetString(Global.CartSessionKey, newCartString);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Policy = "NoAnonymous")]
        public IActionResult Delete(int id, int? _userId)
        {
            purchaseService.Delete(id);
            if (_userId != null)
            {
                int userId = Convert.ToInt32(_userId);
                return RedirectToAction("Review", "User", new {userId});
            }
            return RedirectToAction("Index");
        }
    }
}