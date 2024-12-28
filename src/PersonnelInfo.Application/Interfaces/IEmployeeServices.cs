using PersonnelInfo.Application.DTOs.Entities.Employee;
using PersonnelInfo.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Core.Interfaces;
public interface IEmployeeServices:IServices
{
    void AddAsync(AddEmployeeDto addDto);
    void DeleteByIdAsync(int id);
    void UpdateAsync(EmployeeDto updateDto);
    List<EmployeeDto> GetAllAsync();
    List<EmployeeDto> GetByIdAsync(int id);
}
