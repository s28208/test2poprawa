using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Object = WebApplication1.Models.Object;

namespace WebApplication1.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<ObjectType> ObjectTypes { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Object> Objects { get; set; }
    public DbSet<ObjectOwner> ObjectOwners { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Owner>().HasData(new List<Owner>
            {
                new Owner {
                    OwnerID = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    PhoneNumber = "111111111"
                },
                new Owner {
                    OwnerID = 2,
                    FirstName = "Anna",
                    LastName = "Nowak",
                    PhoneNumber ="222222222"

                }
            });

            modelBuilder.Entity<Object>().HasData(new List<Object>
            {
                new Object {
                    ObjectID = 1,
                    WarehouseID = 1,
                    ObjectTypeID = 1,
                    Width = 4,
                    Height =5
                },
                new Object {
                    ObjectID = 2,
                    WarehouseID = 2,
                    ObjectTypeID = 2,
                    Width = 9,
                    Height = 1
                }
            });

            modelBuilder.Entity<Warehouse>().HasData(new List<Warehouse>
            {
                new Warehouse
                {
                    WarehouseID = 1,
                    Name = "h1"
                    
                },
                new Warehouse
                {
                    WarehouseID = 2,
                    Name = "h2"
                },
                new Warehouse
                {
                    WarehouseID = 3,
                    Name = "h3"
                }
            });

            modelBuilder.Entity<ObjectType>().HasData(new List<ObjectType>
            {
                new ObjectType
                {
                    ObjectTypeId = 1,
                    Name = "ot1"
                },
                new ObjectType
                {
                    ObjectTypeId = 2,
                    Name = "ot2"
                },
                new ObjectType
                {
                    ObjectTypeId = 3,
                    Name = "ot3"
                }
            });

            modelBuilder.Entity<ObjectOwner>().HasData(new List<ObjectOwner>
            {
                new ObjectOwner
                {
                   ObjectID = 1,
                   OwnerID = 1
                },
                new ObjectOwner
                {
                    ObjectID = 1,
                    OwnerID = 2
                },
                new ObjectOwner
                {
                    ObjectID = 2,
                    OwnerID = 1
                    
                },
                
            });
    }
}