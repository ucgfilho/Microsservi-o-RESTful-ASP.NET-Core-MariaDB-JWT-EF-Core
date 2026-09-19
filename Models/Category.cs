using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetoAPI.Models;

[Table("categorias")]
public class Category
{
    [Key]
    [Column("id_categoria")]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    [Column("nome")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(255)]
    [Column("descricao")]
    public string? Description { get; set; }
}
