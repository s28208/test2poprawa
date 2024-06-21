using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class ObjectType
{
    [Key]
    public int ObjectTypeId { get; set; }
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    public ICollection<Object> Objects { get; set; } = new HashSet<Object>();

}