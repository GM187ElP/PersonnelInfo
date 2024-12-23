using PersonnelInfo.Application.DTOs.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Application.Interfaces;
public interface IPersonRepository 
{
    Task AddAsync(AddPersonDto addPersonDto);
    Task DeleteById(int id);
    Task<bool> UpdateAsync(UpdatePersonDto updatePersonDto);
    Task<List<PersonDto>> GetAllAsync();
    Task<PersonDto> GetByIdAsync(int id);
}
