using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerziyskiClima.Data;
using TerziyskiClima.Data.Models;

namespace TerziyskiClima.Services.Repositories
{
    public class ProductRepository
    {
        private readonly TerziyskiClimaDbContext context;
        public ProductRepository(TerziyskiClimaDbContext _context)
        {
            context = _context;
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Remove(int id)
        {
            Product productToRemove = GetProductById(id);
            context.Products.Remove(productToRemove);
            context.SaveChanges();
        }

        public void Edit(int id, Product product)
        {
            Product productToEdit = GetProductById(id);
            if (productToEdit != null)
            {
                productToEdit.Name = product.Name;
                productToEdit.Price = product.Price;
                productToEdit.Description = product.Description;
            }
            context.SaveChanges();
        }
        
        public Product GetProductById(int id)
        {
            return context.Products.FirstOrDefault(x => x.Id == id);
        }

        public List<Product> GetProducts()
        {
            return context.Products.ToList();
        }
    }
}
