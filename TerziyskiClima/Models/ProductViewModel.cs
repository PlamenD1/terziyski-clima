using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerziyskiClima.Data.Models;

namespace TerziyskiClima.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public bool IsInCart { get; set; } = false;

        public ProductViewModel(Product product, bool isInCart)
        {
            Product = product;
            IsInCart = isInCart;
        }
    }
}