using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace WebApplication1.Models;

public class Object
{
    [Key]
    public int ObjectID { get; set; }
    public int WarehouseID { get; set; }
    public int ObjectTypeID { get; set; }

    public int Width { get; set; }
    public int Height { get; set; }


    [ForeignKey(nameof(WarehouseID))]
    public Warehouse Warehouse { get; set; } = null!;
    [ForeignKey(nameof(ObjectTypeID))]
    public ObjectType ObjectType { get; set; } = null!;
    
    public ICollection<ObjectOwner> ObjectOwners { get; set; } = new HashSet<ObjectOwner>();
}