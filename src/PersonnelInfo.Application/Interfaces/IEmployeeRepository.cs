using PersonnelInfo.Application.DTOs.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Application.Interfaces;

string type = "Employee";
public interface IEmployeeRepository
{
    Task AddAsync(TypeFinder.TypeFinderMethod(type,"Add") addDto);
    Task DeleteByIdAsync(int id);
    Task<bool> UpdateAsync(UpdateEmployeeDto UpdateDto);
    Task<List<EmployeeDto>> GetAllAsync();
    Task<EmployeeDto> GetDtoByIdAsync(int id);
}

