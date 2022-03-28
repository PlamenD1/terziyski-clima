using System;
using System.Collections.Generic;
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
    }
}
