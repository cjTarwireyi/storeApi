using store.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DataLayer.Services
{
    public class ProductService: IProductService
    {
        public List<Product> GetProducts()
        {
            // Create a list of products
            List<Product> products = new List<Product>();

            // Add some dummy data to the list
            products.Add(new Product() { Name = "iPhone 13 Pro", Description = "The most advanced iPhone ever", Price = 999.99m, Quantity = 10 });
            products.Add(new Product() { Name = "Samsung Galaxy S22 Ultra", Description = "The ultimate Android smartphone", Price = 899.99m, Quantity = 5 });
            products.Add(new Product() { Name = "MacBook Pro M2", Description = "The most powerful MacBook ever", Price =  299.99m, Quantity = 2 });
            products.Add(new Product() { Name = "AirPods Pro", Description = "The best wireless earbuds on the market", Price = 249.99m, Quantity = 15 });
            products.Add(new Product() { Name = "Apple Watch Series 7", Description = "The most advanced smartwatch ever", Price = 399.99m, Quantity = 10 });

            return products;
        }
    }
}
