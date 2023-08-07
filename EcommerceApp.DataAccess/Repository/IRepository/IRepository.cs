using System.Linq.Expressions;

namespace EcommerceApp.DataAccess.Repository.IRepository;

public interface IRepository<T> where T: class 
{
    // T - Data Type
    IEnumerable<T> GetAll();
    T Get(Expression<Func<T, bool>> filter);
    void Add(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entity);

}