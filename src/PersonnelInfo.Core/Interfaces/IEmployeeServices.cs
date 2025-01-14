using PersonnelInfo.Core.DTOs.Entities.Employee;
using System.Threading;
using System.Threading.Tasks;

namespace PersonnelInfo.Core.Interfaces;
public interface IEmployeeServices
{
    Task AddAsync(AddEmployeeDto addDto, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(long id, CancellationToken cancellationToken = default);
    Task UpdateAsync(EmployeeDto updateDto, CancellationToken cancellationToken = default);
    Task<List<EmployeeDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<EmployeeDto> GetByIdAsync(long id, CancellationToken cancellationToken = default);
}
