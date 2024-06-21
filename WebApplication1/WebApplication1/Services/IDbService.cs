using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IDbService
{
    public Task<ICollection<Owner>> GetCharacterData(int OwnerId);
    public Task<bool> DoesOwnerExist(int OwnerId);
    public Task<bool> DoesObjectExist(int ObjectId);
    //public Task<Object> GetObjectById(int ObjectId);
    public Task AddNewOwnerObject(List<ObjectOwner> objectOwners);
    public Task AddNewOwner(Owner owner);


}