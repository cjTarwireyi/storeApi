using store.DataLayer.Model;

namespace store.DataLayer.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategories();
        Task<Category?> GetCategory(string id);
        Task<bool> AddCategory(Category Category);
        Task<bool> UpdateCategory(Category Category);
        Task<bool> DeleteCategory(string id);
    }
}
