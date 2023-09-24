using Microsoft.EntityFrameworkCore;
using store.Api.Data;
using store.DataLayer.Model;

namespace store.DataLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly StoreDBContext _db;
        public ProductService(StoreDBContext db)
        {           
            _db = db;
        }
        public async Task<bool> AddProduct(Product product)
        {
            await DuplicateCheck(product);
            await _db.Products.AddAsync(product);
            var created = await _db.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var productToRemove = await GetProduct(id);
            if (productToRemove== null)
            {
                return false;
            }
             _db.Products.Remove(productToRemove);
           var deleted = await _db.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<Product?> GetProduct(string id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null)
                throw new Exception("Product awas not found");
            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            await DuplicateCheck(product);
            if (await GetProduct(product.Id.ToString()) == null)
            {
                return false;
            }
            _db.Products.Update(product);
           var updated = await _db.SaveChangesAsync();
            return updated > 0;
        }
        private async Task DuplicateCheck(Product product)
        {
            if (await _db.Products.AnyAsync(x => x.ProductCode == product.ProductCode && x.Id != product.Id))
            {
                throw new DuplicateWaitObjectException("Duplicate Product found in the database");
            }
        }
    }
}
