using projetoAPI.Models;
using projetoAPI.Repositories.Interfaces;
using projetoAPI.Services.Interfaces;

namespace projetoAPI.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Product> CreateAsync(Product product)
    {
        await _repository.AddAsync(product);
        return product;
    }

    public async Task<Product?> UpdateAsync(int id, Product updatedProduct)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
            return null;

        existing.Name = updatedProduct.Name;
        existing.Description = updatedProduct.Description;
        existing.CategoryId = updatedProduct.CategoryId;
        existing.Price = updatedProduct.Price;
        existing.Stock = updatedProduct.Stock;
        existing.IsActive = updatedProduct.IsActive;
        existing.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync();
        return existing;
    }

    public async Task<Product?> PatchAsync(int id, Product updatedProduct)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
            return null;

        if (updatedProduct.Price > 0)
            existing.Price = updatedProduct.Price;

        if (!string.IsNullOrEmpty(updatedProduct.Name))
            existing.Name = updatedProduct.Name;

        if (updatedProduct.Description != null)
            existing.Description = updatedProduct.Description;

        if (updatedProduct.CategoryId != null)
            existing.CategoryId = updatedProduct.CategoryId;

        existing.Stock = updatedProduct.Stock;
        existing.IsActive = updatedProduct.IsActive;
        existing.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
            return false;

        await _repository.DeleteAsync(existing);
        return true;
    }
}
