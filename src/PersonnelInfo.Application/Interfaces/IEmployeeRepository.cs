
using PersonnelInfo.Core.Entities;

namespace PersonnelInfo.Application.Interfaces;
public interface IEmployeeRepository
{
    Task AddAsync(Employee entity);
    Task DeleteByIdAsync(long id);
    Task UpdateAsync(Employee entity);
    Task<List<Employee>> GetAllAsync();
    Task<Employee> GetByIdAsync(long id);
    Task<long> MaxPersonnelCodeAsync();
}
