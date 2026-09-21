using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using projetoAPI.Models;
using projetoAPI.Services.Interfaces;

namespace projetoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        return Ok(await _productService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> PostProduct([FromBody] Product newProduct)
    {
        var product = await _productService.CreateAsync(newProduct);
        return Created("", product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, [FromBody] Product updatedProduct)
    {
        var product = await _productService.UpdateAsync(id, updatedProduct);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchProduct(int id, [FromBody] Product updatedProduct)
    {
        var product = await _productService.PatchAsync(id, updatedProduct);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var deleted = await _productService.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
