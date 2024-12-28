using PersonnelInfo.Application.DTOs.Entities.Employee;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Interfaces;
using PersonnelInfo.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Application.Services;
public class EmployeeServices : IEmployeeServices
{
    IEmployeeRepository _repository;
    IUnitOfWork _unitOfWork;
    public EmployeeServices(IEmployeeRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async void AddAsync(AddEmployeeDto addDto)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var employee = new Employee();
            Mapper.MapToEntity(addDto, employee);
            await _repository.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task DeleteByIdAsync(int id)
    {
        var employee = new Employee();
        employee=(Employee) await _repository.GetByIdAsync(id);
    }

    public List<EmployeeDto> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public List<EmployeeDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateAsync(EmployeeDto updateDto)
    {
        throw new NotImplementedException();
    }
}
