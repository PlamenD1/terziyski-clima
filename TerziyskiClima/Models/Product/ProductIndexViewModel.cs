using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerziyskiClima.Data.Models;

namespace TerziyskiClima.Models.ProductViewModels
{
    public class ProductIndexViewModel
    {
        public List<Product> Products { get; set; }
        public string Role { get; set; }
    }
}