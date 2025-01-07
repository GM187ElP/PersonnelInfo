using PersonnelInfo.Core.DTOs.Entities.Employee;
using PersonnelInfo.Shared.Interfaces;

namespace PersonnelInfo.Core.Interfaces;
public interface IEmployeeServices : IServices
{
    Task AddAsync(AddEmployeeDto addDto);
    Task DeleteByIdAsync(long id);
    Task UpdateAsync(EmployeeDto updateDto);
    Task<List<EmployeeDto>> GetAllAsync();
    Task<EmployeeDto> GetByIdAsync(long id);
}
