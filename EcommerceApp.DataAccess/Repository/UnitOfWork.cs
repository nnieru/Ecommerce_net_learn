using EcommerceApp.DataAccess.Data;
using EcommerceApp.DataAccess.Repository.IRepository;

namespace EcommerceApp.DataAccess.Repository;

public class UnitOfWork: IUnitOfWork
{

    private readonly ApplicationDbContext _context;
    public ICategoryRepository CategoryRepository { get; private set; }

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _context = dbContext;
        CategoryRepository = new CategoryRepository(_context);
    }
   
    public void Save()
    {
        _context.SaveChanges();
    }
}