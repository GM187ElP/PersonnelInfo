using PersonnelInfo.Application.DTOs.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Application.Interfaces;
public interface IEmployeeRepository
{
    Task<bool> AddAsync(object addDto);
    Task<bool> DeleteByIdAsync(int id);
    Task<bool> UpdateAsync(object updateDto);
    Task<List<object>> GetAllAsync();
    Task<object> GetByIdAsync(int id);
}
