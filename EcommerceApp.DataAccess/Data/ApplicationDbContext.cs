using Microsoft.EntityFrameworkCore;
using EXommerceApp.Models.Models;

namespace EcommerceApp.DataAccess.Data;

public class ApplicationDbContext: DbContext 
{

    // constructor
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    // table declarations
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    // seeding - add initial data when table created
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>().HasData(
            new Category {Id = 1, Name = "Action", DisplayOrder = 1},
            new Category {Id = 2, Name = "SciFi", DisplayOrder = 2},
            new Category {Id = 3, Name = "History", DisplayOrder = 3}
            );
    
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Title = "Fortune Of Time",
                Author = "Billy Spark",
                Description = "Lorem ipsum",
                ISBN = "SWD9999001",
                Price = 90,
                ListPrice = 99,
                Price50 = 85,
                Price100 = 80,
                CategoryId = 2,
                ImageUrl = ""
            },
            new Product
            {
                Id = 2,
                Title = "Dark Skies",
                Author = "Nancy Hoover",
                Description = "Lorem ipsum",
                ISBN = "CAW777777701",
                Price = 30,
                ListPrice = 40,
                Price50 = 25,
                Price100 = 20,
                CategoryId = 2,
                ImageUrl = ""
            },
            new Product
            {
                Id = 3,
                Title = "Cotton Candy",
                Author = "Abby Muscles",
                Description = "Lorem ipsum",
                ISBN = "WS333333301",
                ListPrice = 70,
                Price = 65,
                Price50 = 60,
                Price100 = 55,
                CategoryId = 3,
                ImageUrl = ""
            }, new Product
            {
                Id = 4,
                Title = "Fortune Of Time",
                Author = "Billy Spark",
                Description = "Lorem ipsum",
                ISBN = "SOTJ000001",
                ListPrice = 30,
                Price = 27,
                Price50 = 25,
                Price100 = 20,
                CategoryId = 1,
                ImageUrl = ""
            }, new Product
            {
                Id = 5,
                Title = "Leaves and Worders",
                Author = "Laura Phantom",
                Description = "Lorem ipsum",
                ISBN = "FOT000001",
                ListPrice = 25,
                Price = 23,
                Price50 = 22,
                Price100 = 20,
                CategoryId = 1,
                ImageUrl = ""
                
            }
            );
    }
}