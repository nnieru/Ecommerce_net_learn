using ECommereApp_Razor.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommereApp_Razor.Data;

public class AplicationDbContext: DbContext
{
    public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
    {
        
    }

    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
            new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
            new Category { Id = 3, Name = "History", DisplayOrder = 3 }
        );
    }
}