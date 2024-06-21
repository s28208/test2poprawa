using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;
[Table("Object_Owner")]
[PrimaryKey(nameof(ObjectID), nameof(OwnerID))]
public class ObjectOwner
{
    public int ObjectID { get; set; }
    public int OwnerID { get; set; }
    [ForeignKey(nameof(ObjectID))]
    public Object Object { get; set; } = null!;
    [ForeignKey(nameof(OwnerID))]
    public Owner Owner { get; set; } = null!;
}

