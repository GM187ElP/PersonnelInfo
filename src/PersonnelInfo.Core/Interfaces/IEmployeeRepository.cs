using PersonnelInfo.Shared.Interfaces;

namespace PersonnelInfo.Core.Interfaces;
public interface IEmployeeRepository:IRepository
{
    Task<bool> AddAsync(object entity);
    Task<bool> DeleteAsync(object entity);
    Task<bool> UpdateAsync(object entity);
    Task<List<object>> GetAllAsync();
    Task<object> GetByIdAsync(int id);
}
