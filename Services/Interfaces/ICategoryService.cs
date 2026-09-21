using projetoAPI.Models;

namespace projetoAPI.Services.Interfaces;

public interface ICategoryService
{
    Task<List<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task<Category> CreateAsync(Category category);
    Task<Category?> UpdateAsync(int id, Category updatedCategory);
    Task<Category?> PatchAsync(int id, Category updatedCategory);
    Task<bool> DeleteAsync(int id);
}
