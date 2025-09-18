using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cronache_di_DnD.Entities;

[Table("Users")]
public class UserEntity
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Surname { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    public bool DM { get; set; } = false;
}
