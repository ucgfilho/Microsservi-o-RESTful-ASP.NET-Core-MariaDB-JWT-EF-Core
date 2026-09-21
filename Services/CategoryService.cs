using projetoAPI.Models;
using projetoAPI.Repositories.Interfaces;
using projetoAPI.Services.Interfaces;

namespace projetoAPI.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Category> CreateAsync(Category category)
    {
        await _repository.AddAsync(category);
        return category;
    }

    public async Task<Category?> UpdateAsync(int id, Category updatedCategory)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
            return null;

        existing.Name = updatedCategory.Name;
        existing.Description = updatedCategory.Description;

        await _repository.UpdateAsync();
        return existing;
    }

    public async Task<Category?> PatchAsync(int id, Category updatedCategory)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
            return null;

        if (!string.IsNullOrEmpty(updatedCategory.Name))
            existing.Name = updatedCategory.Name;

        if (updatedCategory.Description != null)
            existing.Description = updatedCategory.Description;

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
