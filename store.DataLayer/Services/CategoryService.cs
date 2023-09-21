using store.DataLayer.Model;

namespace store.DataLayer.Services
{
    internal class CategoryService : ICategoryService
    {
        public Task<bool> AddCategory(Category Category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategory(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetCategory(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategory(Category Category)
        {
            throw new NotImplementedException();
        }
    }
}
