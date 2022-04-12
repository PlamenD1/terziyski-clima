using System;
using System.Collections.Generic;
using System.Text;
using TerziyskiClima.Data.Models;

namespace TerziyskiClima.Services.Interfaces
{
    public interface IProductService
    {
        public Product Add(string name, double price, string description);
        public void Edit(int id, string name, double price, string description);
        public void Remove(int id);
        public Product GetProductById(int id);
        public List<Product> GetProducts();
    }
}
