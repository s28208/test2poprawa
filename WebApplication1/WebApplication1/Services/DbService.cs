using System.Formats.Asn1;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using Object = System.Object;

namespace WebApplication1.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<ICollection<Owner>> GetCharacterData(int OwnerId)
    {
        if (!await (DoesOwnerExist(OwnerId)))
        {
            throw new AsnContentException("Not Found Owner");
            
        }
        
        return await _context.Owners

            .Include(e => e.ObjectOwners)
            .ThenInclude(e => e.Object)
            .ThenInclude(e=> e.Warehouse)
            .ThenInclude(e=> e.Objects)
            .ThenInclude(e=>e.ObjectType)
            .Where(e => e.OwnerID == OwnerId)
            .ToListAsync();
    }

    /*public async Task<Object> GetObjectById(int ObjectId)
    {
        return await _context.Objects.FirstOrDefault(e => e.ObjectID == ObjectId);
    }*/

    public async Task<bool> DoesOwnerExist(int OwnerId)
    {
        return await _context.Owners.AnyAsync(e => e.OwnerID == OwnerId);
    }
    
    public async Task<bool> DoesObjectExist(int ObjectId)
    {
        return await _context.Objects.AnyAsync(e => e.ObjectID == ObjectId);
    }
    public async Task AddNewOwnerObject(List<ObjectOwner> objectOwners)
    {
        await _context.AddRangeAsync(objectOwners);
        await _context.SaveChangesAsync();
    }
    public async Task AddNewOwner(Owner owner)
    {
        await _context.AddAsync(owner);
        await _context.SaveChangesAsync();
    }
    
}