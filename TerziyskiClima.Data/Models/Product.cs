using System;
using System.Collections.Generic;
using System.Text;

namespace TerziyskiClima.Data.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }

        public Product(string name, decimal price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }
    }
}
