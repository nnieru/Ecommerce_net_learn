namespace EcommerceApp.DataAccess.Repository.IRepository;

public interface IUnitOfWork
{
    ICategoryRepository CategoryRepository { get; }

    void Save();

}