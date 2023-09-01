using store.DataLayer.Model;

namespace store.DataLayer.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product? GetProduct(string id);
        bool AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);    
    }
}
