using System;
using System.Collections.Generic;
using System.Text;
using TerziyskiClima.Services.Extensions;
using TerziyskiClima.Data.Models;
using TerziyskiClima.Services.Interfaces;

namespace TerziyskiClima.Services
{
    public class CartService : ICartService
    {
        public string AddToCart(Product productToAdd, string cartString)
        {
            Cart cart = cartString.ToCart();
            cart.Items.Add(new CartItem(productToAdd, 1));
            return cart.ToString();
        }

        public string RemoveFromCart(int productId, string cartString)
        {
            Cart cart = cartString.ToCart();
            cart.Items.RemoveAll(x => x.Product.Id == productId);
            return cart.ToString();
        }

        public List<CartItem> GetCartContent(string cartString)
        {
            Cart cart = cartString.ToCart();
            return cart.Items;
        }
    }
}