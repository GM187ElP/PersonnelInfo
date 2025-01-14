using PersonnelInfo.Core.DTOs.Entities.Employee;

namespace PersonnelInfo.Core.Interfaces;
public interface IEmployeeServices
{
    Task AddAsync(AddEmployeeDto addDto);
    Task DeleteByIdAsync(long id);
    Task UpdateAsync(EmployeeDto updateDto);
    Task<List<EmployeeDto>> GetAllAsync();
    Task<EmployeeDto> GetByIdAsync(long id);
}
