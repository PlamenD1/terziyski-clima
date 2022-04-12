using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerziyskiClima.Data;
using TerziyskiClima.Data.Models;

namespace TerziyskiClima.Services.Repositories
{
    public class PurchaseRepository
    {
        private readonly TerziyskiClimaDbContext context;

        public PurchaseRepository(TerziyskiClimaDbContext _context)
        {
            context = _context;
        }

        public void Add(Purchase purchase)
        {
            context.Purchases.Add(purchase);
            context.SaveChanges();
        }

        public List<Purchase> GetPurchasesByUserId(int userId)
        {
            return context.Purchases.Include("Product").Where(x => x.UserId == userId).ToList();
        }

        public void Remove(int id)
        {
            Purchase purchaseToRemove = context.Purchases.Where(x => x.Id == id).FirstOrDefault();
            context.Purchases.Remove(purchaseToRemove);
            context.SaveChanges();
        }
    }
}