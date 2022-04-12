using System;
using System.Collections.Generic;
using System.Text;
using TerziyskiClima.Services.Extensions;
using TerziyskiClima.Data.Models;
using TerziyskiClima.Services.Interfaces;
using System.Linq;

namespace TerziyskiClima.Services
{
    public class CartService : ICartService
    {
        public string AddToCart(Product productToAdd, string cartString)
        {
            Cart cart = cartString.ToCart();
            CartItem alreadyExistingItem = cart.Items.Where(x => x.Product.Id == productToAdd.Id).FirstOrDefault();
            if (alreadyExistingItem != null) alreadyExistingItem.Quantity += 1;
            else cart.Items.Add(new CartItem(productToAdd, 1));
            return cart.ToString();
        }

        public string RemoveFromCart(int productId, string cartString)
        {
            Cart cart = cartString.ToCart();
            cart.Items.RemoveAll(x => x.Product.Id == productId);
            return cart.ToString();
        }

        public string ChangeQuantity(int productId, int quantity, string cartString)
        {
            Cart cart = cartString.ToCart();
            CartItem cartItem = cart.Items.Where(x => x.Product.Id == productId).FirstOrDefault();
            if (cartItem != null) cartItem.Quantity = quantity;
            return cart.ToString();
        }

        public string ClearCart(string cartString)
        {
            Cart cart = cartString.ToCart();
            cart.Items.RemoveAll(x => true);
            return cart.ToString();
        }

        public List<CartItem> GetCartContent(string cartString)
        {
            Cart cart = cartString.ToCart();
            return cart.Items;
        }
    }
}