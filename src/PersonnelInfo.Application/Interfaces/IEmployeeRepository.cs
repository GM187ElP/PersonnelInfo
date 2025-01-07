using PersonnelInfo.Core.Entities;
using PersonnelInfo.Shared.Interfaces;

namespace PersonnelInfo.Application.Interfaces;
public interface IEmployeeRepository : IRepository
{
    Task AddAsync(object entity);
    Task DeleteByIdAsync(long id);
    Task Update(object entity);
    Task<List<Employee>> GetAllAsync();
    Task<object> GetByIdAsync(long id);
}
