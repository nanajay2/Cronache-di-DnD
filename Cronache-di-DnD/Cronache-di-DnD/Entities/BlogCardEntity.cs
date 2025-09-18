using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cronache_di_DnD.Entities;

[Table("BlogCards")]
public class BlogCardEntity
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public string Content { get; set; }
}