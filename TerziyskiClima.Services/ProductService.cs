using System;
using System.Collections.Generic;
using System.Text;
using TerziyskiClima.Data;
using TerziyskiClima.Data.Models;
using TerziyskiClima.Services.Interfaces;
using TerziyskiClima.Services.Repositories;

namespace TerziyskiClima.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository productRepository;

        public ProductService(TerziyskiClimaDbContext _context)
        {
            productRepository = new ProductRepository(_context);
        }

        public Product Add(string name, decimal price, string description)
        {
            Product productToAdd = new Product(name, price, description);
            productRepository.Add(productToAdd);
            return productToAdd;
        }

        public void Edit(int id, string name, decimal price, string description)
        {
            Product editedProduct = new Product(name, price, description);
            productRepository.Edit(id, editedProduct);
        }

        public void Remove(int id)
        {
            productRepository.Remove(id);
        }

        public Product GetProductById(int id)
        {
            return productRepository.GetProductById(id);
        }

        public List<Product> GetProducts()
        {
            return productRepository.GetProducts();
        }
    }
}