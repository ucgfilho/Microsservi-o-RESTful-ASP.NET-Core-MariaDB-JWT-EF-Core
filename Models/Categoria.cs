using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetoAPI.Models;

[Table("categorias")]
public class Categoria
{
    [Key]
    [Column("id_categoria")]
    public int IdCategoria { get; set; }

    [Required]
    [MaxLength(255)]
    [Column("nome")]
    public string Nome { get; set; } = string.Empty;

    [MaxLength(255)]
    [Column("descricao")]
    public string? Descricao { get; set; }
}
