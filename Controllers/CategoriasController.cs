using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using projetoAPI.Data;
using projetoAPI.Models;

namespace projetoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CategoriasController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetCategorias()
    {
        return Ok(_context.Categorias.ToList());
    }

    [HttpPost]
    public IActionResult PostCategoria([FromBody] Categoria novaCategoria)
    {
        _context.Categorias.Add(novaCategoria);
        _context.SaveChanges();

        return Created("", novaCategoria);
    }

    [HttpPut("{id}")]
    public IActionResult PutCategoria(int id, [FromBody] Categoria categoriaAtualizada)
    {
        var categoriaNoBanco = _context.Categorias.Find(id);
        
        if (categoriaNoBanco == null)
            return NotFound();

        categoriaNoBanco.Nome = categoriaAtualizada.Nome;
        categoriaNoBanco.Descricao = categoriaAtualizada.Descricao;

        _context.SaveChanges();
        return Ok(categoriaNoBanco);
    }

    [HttpPatch("{id}")]
    public IActionResult PatchCategoria(int id, [FromBody] Categoria categoriaAtualizada)
    {
        var categoriaNoBanco = _context.Categorias.Find(id);
        
        if (categoriaNoBanco == null)
            return NotFound();

        if (!string.IsNullOrEmpty(categoriaAtualizada.Nome))
            categoriaNoBanco.Nome = categoriaAtualizada.Nome;

        if (categoriaAtualizada.Descricao != null)
            categoriaNoBanco.Descricao = categoriaAtualizada.Descricao;

        _context.SaveChanges();
        return Ok(categoriaNoBanco);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategoria(int id)
    {
        var categoriaNoBanco = _context.Categorias.Find(id);
        
        if (categoriaNoBanco == null)
            return NotFound();

        _context.Categorias.Remove(categoriaNoBanco);
        _context.SaveChanges();

        return NoContent();
    }
}
