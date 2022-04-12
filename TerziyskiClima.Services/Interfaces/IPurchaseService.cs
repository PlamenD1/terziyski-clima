using System;
using System.Collections.Generic;
using System.Text;
using TerziyskiClima.Data.Models;

namespace TerziyskiClima.Services.Interfaces
{
    public interface IPurchaseService
    {
        public void PurchaseFromCart(int userId, string cartString);
        public List<Purchase> GetPurchasesByUserId(int userId);
        public void Delete(int id);
    }
}
