using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using projetoAPI.Data;
using projetoAPI.Models;

namespace projetoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetProdutos()
    {
        return Ok(_context.Produtos.ToList());
    }

    [HttpPost]
    public IActionResult PostProdutos([FromBody] Produto novoProduto)
    {
        _context.Produtos.Add(novoProduto);
        _context.SaveChanges();

        return Created("", novoProduto);
    }

    [HttpPut("{id}")]
    public IActionResult PutProduto(int id, [FromBody] Produto produtoAtualizado)
    {
        var produtoNoBanco = _context.Produtos.Find(id);
        
        if (produtoNoBanco == null)
            return NotFound();

        produtoNoBanco.Nome = produtoAtualizado.Nome;
        produtoNoBanco.Descricao = produtoAtualizado.Descricao;
        produtoNoBanco.CategoriaId = produtoAtualizado.CategoriaId;
        produtoNoBanco.Preco = produtoAtualizado.Preco;
        produtoNoBanco.Estoque = produtoAtualizado.Estoque;
        produtoNoBanco.Ativo = produtoAtualizado.Ativo;
        produtoNoBanco.AtualizadoEm = DateTime.UtcNow;

        _context.SaveChanges();
        return Ok(produtoNoBanco);
    }

    [HttpPatch("{id}")]
    public IActionResult PatchProduto(int id, [FromBody] Produto produtoAtualizado)
    {
        var produtoNoBanco = _context.Produtos.Find(id);
        
        if (produtoNoBanco == null)
            return NotFound();

        if (produtoAtualizado.Preco > 0) 
            produtoNoBanco.Preco = produtoAtualizado.Preco;
            
        if (!string.IsNullOrEmpty(produtoAtualizado.Nome)) 
            produtoNoBanco.Nome = produtoAtualizado.Nome;

        if (produtoAtualizado.Descricao != null)
            produtoNoBanco.Descricao = produtoAtualizado.Descricao;

        if (produtoAtualizado.CategoriaId != null)
            produtoNoBanco.CategoriaId = produtoAtualizado.CategoriaId;

        produtoNoBanco.Estoque = produtoAtualizado.Estoque;
        produtoNoBanco.Ativo = produtoAtualizado.Ativo;

        produtoNoBanco.AtualizadoEm = DateTime.UtcNow;

        _context.SaveChanges();
        return Ok(produtoNoBanco);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduto(int id)
    {
        var produtoNoBanco = _context.Produtos.Find(id);
        
        if (produtoNoBanco == null)
            return NotFound();

        _context.Produtos.Remove(produtoNoBanco);
        _context.SaveChanges();

        return NoContent();
    }
}