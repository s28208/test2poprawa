using System.Formats.Asn1;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services;
using Object = System.Object;

namespace WebApplication1.Controllers;

[Route("api/owners")]
[ApiController]
public class OwnerController : ControllerBase
{
    private readonly IDbService _dbService;

    public OwnerController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{OwnerId:int}")]
    public async Task<IActionResult> GetOwnerData(int OwnerId)
    {
        var character = await _dbService.GetCharacterData(OwnerId);
        return Ok(character.Select(e => new OwnerDTO()
        {
            FirstName = e.FirstName,
            LastName = e.LastName,
            PhoneNumber = e.PhoneNumber,
            
            ObjectOwners = e.ObjectOwners.Select(p => new ObjectOwnerDTO()
            {
                ObjectId = p.ObjectID,
                Width = p.Object.Width,
                Height = p.Object.Height,
                Type = p.Object.ObjectType.Name,
                Warehouse = p.Object.Warehouse.Name
            }).ToList(),
        }));
       
    }

    [HttpPost]
    public async Task<IActionResult> AddOwnerData(NewOwnerDTO newOwnerDto)
    {

        var newowner = new Owner()
        {
            FirstName = newOwnerDto.FirstName,
            LastName = newOwnerDto.LastName,
            PhoneNumber = newOwnerDto.PhoneNumber
        };
        var idnewowner = _dbService.AddNewOwner(newowner);
        var objects = new List<Object>();
        foreach (var tmp in newOwnerDto.NewOwnerObjectDtos)
        {
            if (!await (_dbService.DoesObjectExist(tmp.ObjectId)))
            {
                throw new AsnContentException("Not Found Object");
            }

            /*var newOO = new ObjectOwner()
            {
                ObjectID = tmp.ObjectId,
                OwnerID = 
            }*/
        }
        
        
        return Ok();
    }
}