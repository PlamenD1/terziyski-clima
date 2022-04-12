using System;
using System.Collections.Generic;
using System.Text;
using TerziyskiClima.Data;
using TerziyskiClima.Data.Models;
using TerziyskiClima.Services.Extensions;
using TerziyskiClima.Services.Interfaces;
using TerziyskiClima.Services.Repositories;

namespace TerziyskiClima.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly PurchaseRepository purchaseRepository;

        public PurchaseService(TerziyskiClimaDbContext context)
        {
            purchaseRepository = new PurchaseRepository(context);
        }

        public void PurchaseFromCart(int userId, string cartString)
        {
            Cart cart = cartString.ToCart();
            foreach (var item in cart.Items)
            {
                
                Purchase purchase = new Purchase(userId, item.Product.Id, DateTime.Now, item.Quantity);
                purchaseRepository.Add(purchase);
            }
        }

        public List<Purchase> GetPurchasesByUserId(int userId)
        {
            return purchaseRepository.GetPurchasesByUserId(userId);
        }

        public void Delete(int id)
        {
            purchaseRepository.Remove(id);
        }
    }
}