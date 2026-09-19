using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetoAPI.Models;

[Table("produtos")]
public class Produto
{
    [Key]
    [Column("id_produto")]
    public int IdProduto { get; set; }

    [Required]
    [MaxLength(150)]
    [Column("nome")]
    public string Nome { get; set; } = string.Empty;

    [MaxLength(255)]
    [Column("descricao")]
    public string? Descricao { get; set; }

    [Column("categoria_id")]
    public int? CategoriaId { get; set; }

    [Column("preco")]
    public decimal Preco { get; set; }

    [Column("estoque")]
    public int Estoque { get; set; }

    [Column("ativo")]
    public bool Ativo { get; set; } = true;

    [Column("criado_em")]
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    [Column("atualizado_em")]
    public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;
}
