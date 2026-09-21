using projetoAPI.Models;

namespace projetoAPI.Services.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product> CreateAsync(Product product);
    Task<Product?> UpdateAsync(int id, Product updatedProduct);
    Task<Product?> PatchAsync(int id, Product updatedProduct);
    Task<bool> DeleteAsync(int id);
}
