using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using projetoAPI.Data;
using projetoAPI.Models;

namespace projetoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(_context.Products.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        var existingProduct = _context.Products.Find(id);

        if (existingProduct == null)
            return NotFound();

        return Ok(existingProduct);
    }

    [HttpPost]
    public IActionResult PostProduct([FromBody] Product newProduct)
    {
        _context.Products.Add(newProduct);
        _context.SaveChanges();

        return Created("", newProduct);
    }

    [HttpPut("{id}")]
    public IActionResult PutProduct(int id, [FromBody] Product updatedProduct)
    {
        var existingProduct = _context.Products.Find(id);
        
        if (existingProduct == null)
            return NotFound();

        existingProduct.Name = updatedProduct.Name;
        existingProduct.Description = updatedProduct.Description;
        existingProduct.CategoryId = updatedProduct.CategoryId;
        existingProduct.Price = updatedProduct.Price;
        existingProduct.Stock = updatedProduct.Stock;
        existingProduct.IsActive = updatedProduct.IsActive;
        existingProduct.UpdatedAt = DateTime.UtcNow;

        _context.SaveChanges();
        return Ok(existingProduct);
    }

    [HttpPatch("{id}")]
    public IActionResult PatchProduct(int id, [FromBody] Product updatedProduct)
    {
        var existingProduct = _context.Products.Find(id);
        
        if (existingProduct == null)
            return NotFound();

        if (updatedProduct.Price > 0) 
            existingProduct.Price = updatedProduct.Price;
            
        if (!string.IsNullOrEmpty(updatedProduct.Name)) 
            existingProduct.Name = updatedProduct.Name;

        if (updatedProduct.Description != null)
            existingProduct.Description = updatedProduct.Description;

        if (updatedProduct.CategoryId != null)
            existingProduct.CategoryId = updatedProduct.CategoryId;

        existingProduct.Stock = updatedProduct.Stock;
        existingProduct.IsActive = updatedProduct.IsActive;
        existingProduct.UpdatedAt = DateTime.UtcNow;

        _context.SaveChanges();
        return Ok(existingProduct);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var existingProduct = _context.Products.Find(id);
        
        if (existingProduct == null)
            return NotFound();

        _context.Products.Remove(existingProduct);
        _context.SaveChanges();

        return NoContent();
    }
}
