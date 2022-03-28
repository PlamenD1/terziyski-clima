using System;
using System.Collections.Generic;
using System.Text;
using TerziyskiClima.Data.Models;

namespace TerziyskiClima.Services.Interfaces
{
    public interface ICartService
    {
        public string AddToCart(Product productToAdd, string cartString);
        public string RemoveFromCart(int productId, string cartString);
        public List<CartItem> GetCartContent(string cartString);
    }
}