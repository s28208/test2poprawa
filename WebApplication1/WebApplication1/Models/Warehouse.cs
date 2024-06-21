using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Warehouse
{
    [Key]
    public int WarehouseID { get; set; }
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    public ICollection<Object> Objects { get; set; } = new HashSet<Object>();
}