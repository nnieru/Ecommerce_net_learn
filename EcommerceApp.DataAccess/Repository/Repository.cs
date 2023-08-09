using System.Linq.Expressions;
using EcommerceApp.DataAccess.Data;
using EcommerceApp.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    internal DbSet<T> dbSet; 
    
    public Repository(ApplicationDbContext dbContext)
    {
        _context = dbContext;
        this.dbSet = _context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        IQueryable<T> query = dbSet;
        return query.ToList();
    }

    public T Get(Expression<Func<T, bool>> filter)
    {
        IQueryable<T> query = dbSet;
        query = query.Where(filter);
        return query.FirstOrDefault();
    }

    public void Add(T entity)
    {
        _context.Add(entity);
    }

    public void Remove(T entity)
    {
        dbSet.Remove(entity); 
    }

    public void RemoveRange(IEnumerable<T> entity)
    {
        dbSet.RemoveRange(entity);
    }
}