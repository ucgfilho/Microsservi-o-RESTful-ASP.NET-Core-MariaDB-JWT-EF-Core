using projetoAPI.Models;

namespace projetoAPI.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task AddAsync(Category category);
    Task UpdateAsync();
    Task DeleteAsync(Category category);
}
