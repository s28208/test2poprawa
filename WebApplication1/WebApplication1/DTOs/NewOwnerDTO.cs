using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;

public class NewOwnerDTO
{
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required]
    public string PhoneNumber { get; set; } = string.Empty;
    [Required]

    public ICollection<NewOwnerObjectDTO> NewOwnerObjectDtos { get; set; }  = null!;
}

public class NewOwnerObjectDTO
{
    [Required]
    public int ObjectId { get; set; } 
}