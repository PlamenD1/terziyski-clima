using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TerziyskiClima.Data.Models;

namespace TerziyskiClima.Services
{
    public class CartItem
    {
        public Product Product { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Количеството не може да е по-малко от 1")]
        public int Quantity { get; set; }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
