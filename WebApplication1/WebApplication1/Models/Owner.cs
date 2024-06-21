using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Owner
{
    [Key]
    public int OwnerID { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;
    [MaxLength(9)]
    public string PhoneNumber { get; set; } = string.Empty;

    public ICollection<ObjectOwner> ObjectOwners { get; set; } = new HashSet<ObjectOwner>();
}