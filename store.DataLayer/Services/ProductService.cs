using store.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DataLayer.Services
{
    public class ProductService : IProductService
    {
        private List<Product> _products;
        public ProductService()
        {
            _products = new List<Product>()
            {
                new Product() {Id ="1", Name = "iPhone 13 Pro", Description = "The most advanced iPhone ever", Price = 999.99m, Quantity = 10 },
                new Product() {Id ="2",Name = "Samsung Galaxy S22 Ultra", Description = "The ultimate Android smartphone", Price = 899.99m, Quantity = 5 },
                new Product() {Id ="3",Name = "MacBook Pro M2", Description = "The most powerful MacBook ever", Price = 299.99m, Quantity = 2 },
                new Product() {Id ="4",Name = "AirPods Pro", Description = "The best wireless earbuds on the market", Price = 249.99m, Quantity = 15 },
                new Product() {Id ="5",Name = "Apple Watch Series 7", Description = "The most advanced smartwatch ever", Price = 399.99m, Quantity = 10 }
            };

            // Add some dummy data to the list

        }
        public bool AddProduct(Product product)
        {
            _products.Add(product);
            return true;
        }

        public Product GetProduct(string id)
        {
           return _products.FirstOrDefault(x => x.Id == id);
        }

        public List<Product> GetProducts()
        {

            return _products;
        }
    }
}
