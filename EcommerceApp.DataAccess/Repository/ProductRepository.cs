using System.Linq.Expressions;
using EcommerceApp.DataAccess.Data;
using EcommerceApp.DataAccess.Repository.IRepository;
using EXommerceApp.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.DataAccess.Repository;

public class ProductRepository: Repository<Product>, IProductRepository
{
    private readonly ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
    }
}