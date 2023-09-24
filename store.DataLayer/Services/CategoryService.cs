using Microsoft.EntityFrameworkCore;
using store.Api.Data;
using store.DataLayer.Model;

namespace store.DataLayer.Services
{
    internal class CategoryService : ICategoryService
    {
        private readonly StoreDBContext _db;

        public CategoryService(StoreDBContext db)
        {
            _db = db;
        }
        public async Task<bool> AddCategory(Category Category)
        {
            _db.Categories.Add(Category);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCategory(string id)
        {
            var categoryToRemopve = await GetCategory(id);

            _db.Categories.Remove(categoryToRemopve);

            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategory(string id)
        {
            var category = await _db.Categories.FindAsync(id);

            if (category == null)
                throw new Exception("Category awas not found");

            return category;
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            await GetCategory(category.Id.ToString());
            _db.Categories.Update(category);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
