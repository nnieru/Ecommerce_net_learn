using EXommerceApp.Models.Models;

namespace EcommerceApp.DataAccess.Repository.IRepository;

public interface ICategoryRepository: IRepository<Category >
{
     void Update(Category obj);
     void Save();
}