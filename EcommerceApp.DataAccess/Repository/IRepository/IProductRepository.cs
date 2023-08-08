using EXommerceApp.Models.Models;
namespace EcommerceApp.DataAccess.Repository.IRepository;

public interface IProductRepository: IRepository<Product>
{
    void Update(Product product);
}