using store.DataLayer.Model;

namespace store.DataLayer.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<Product?> GetProduct(string id);
        Task<bool> AddProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string id);    
    }
}
