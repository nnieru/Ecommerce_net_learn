using System.Linq.Expressions;
using EcommerceApp.DataAccess.Data;
using EcommerceApp.DataAccess.Repository.IRepository;
using EXommerceApp.Models.Models;

namespace EcommerceApp.DataAccess.Repository;

public class CategoryRepository: Repository<Category>, ICategoryRepository
{
    private readonly ApplicationDbContext _context;
    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }

    public void Update(Category obj)
    {
        _context.Update(obj);
    }
    
}