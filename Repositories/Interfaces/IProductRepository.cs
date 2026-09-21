using projetoAPI.Models;

namespace projetoAPI.Repositories.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task AddAsync(Product product);
    Task UpdateAsync();
    Task DeleteAsync(Product product);
}
