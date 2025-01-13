
namespace PersonnelInfo.Application.Interfaces;
public interface IRepository<T> where T : class
{
    Task AddAsync(T entity);
    void DeleteById(long id);
    void Update(T entity);
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(long id);
}
