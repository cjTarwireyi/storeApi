using store.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DataLayer.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProduct(string id);
        bool AddProduct(Product product);
    }
}
