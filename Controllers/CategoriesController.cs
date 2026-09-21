using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using projetoAPI.Data;
using projetoAPI.Models;

namespace projetoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CategoriesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetCategories()
    {
        return Ok(_context.Categories.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetCategoryById(int id)
    {
        var existingCategory = _context.Categories.Find(id);

        if (existingCategory == null)
            return NotFound();

        return Ok(existingCategory);
    }

    [HttpPost]
    public IActionResult PostCategory([FromBody] Category newCategory)
    {
        _context.Categories.Add(newCategory);
        _context.SaveChanges();

        return Created("", newCategory);
    }

    [HttpPut("{id}")]
    public IActionResult PutCategory(int id, [FromBody] Category updatedCategory)
    {
        var existingCategory = _context.Categories.Find(id);
        
        if (existingCategory == null)
            return NotFound();

        existingCategory.Name = updatedCategory.Name;
        existingCategory.Description = updatedCategory.Description;

        _context.SaveChanges();
        return Ok(existingCategory);
    }

    [HttpPatch("{id}")]
    public IActionResult PatchCategory(int id, [FromBody] Category updatedCategory)
    {
        var existingCategory = _context.Categories.Find(id);
        
        if (existingCategory == null)
            return NotFound();

        if (!string.IsNullOrEmpty(updatedCategory.Name))
            existingCategory.Name = updatedCategory.Name;

        if (updatedCategory.Description != null)
            existingCategory.Description = updatedCategory.Description;

        _context.SaveChanges();
        return Ok(existingCategory);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        var existingCategory = _context.Categories.Find(id);
        
        if (existingCategory == null)
            return NotFound();

        _context.Categories.Remove(existingCategory);
        _context.SaveChanges();

        return NoContent();
    }
}
