namespace WebApplication1.DTOs;

public class OwnerDTO
{
   
  
 
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
  
    public string PhoneNumber { get; set; } = string.Empty;

    public ICollection<ObjectOwnerDTO> ObjectOwners { get; set; }  = null!;
}

